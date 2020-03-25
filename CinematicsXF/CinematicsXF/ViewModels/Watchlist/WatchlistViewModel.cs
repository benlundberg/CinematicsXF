using CinematicsXF.Core;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CinematicsXF
{
    public class WatchlistViewModel : BaseViewModel
    {
        public WatchlistViewModel()
        {
            this.watchlistService = ComponentContainer.Current.Resolve<IWatchlistService>();

            watchlistService.WatchlistChanged += WatchlistService_WatchlistChanged;
        }

        public async override void Appearing()
        {
            base.Appearing();

            await LoadWatchListAsync();
        }

        private void WatchlistService_WatchlistChanged(object sender, MediaItem item)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (WatchlistItems == null)
                {
                    return;
                }

                if (item.IsFavourite && !WatchlistItems.Any(x => x.Id == item.Id))
                {
                    WatchlistItems.Add(item);
                }
                else
                {
                    var toRemove = WatchlistItems.FirstOrDefault(x => x.Id == item.Id);
                    WatchlistItems.Remove(toRemove);
                }
            });
        }

        private async Task LoadWatchListAsync()
        {
            try
            {
                IsBusy = true;

                var watchList = await watchlistService.GetAsync();

                WatchlistItems = watchList?.Any() == true ? new ObservableCollection<MediaItem>(watchList) : new ObservableCollection<MediaItem>();
            }
            catch (Exception ex)
            {
                ex.Print();
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void MediaSelected(MediaItem mediaItem)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (IsBusy)
                {
                    return;
                }

                try
                {
                    IsBusy = true;

                    if (mediaItem is MovieItem movieDetail)
                    {
                        await Navigation.PushAsync(ViewContainer.Current.CreatePage(new MovieDetailViewModel(movieDetail)));
                    }
                }
                catch (Exception ex)
                {
                    ex.Print();
                }
                finally
                {
                    IsBusy = false;
                }
            });
        }

        private MediaItem selectedMedia;
        public MediaItem SelectedMedia
        {
            get { return selectedMedia; }
            set
            {
                selectedMedia = value;

                if (selectedMedia != null)
                {
                    MediaSelected(selectedMedia);
                }
            }
        }

        public ObservableCollection<MediaItem> WatchlistItems { get; private set; }

        private readonly IWatchlistService watchlistService;
    }
}
