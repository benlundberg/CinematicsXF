using CinematicsXF.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CinematicsXF
{
    public class TvViewModel : BaseViewModel
    {
        public TvViewModel()
        {
            tvService = ComponentContainer.Current.Resolve<ITvService>();
        }

        public override void Appearing()
        {
            base.Appearing();

            Device.BeginInvokeOnMainThread(async () =>
            {
                await LoadTvAsync();
            });
        }

        private ICommand itemClickedCommand;
        public ICommand ItemClickedCommand => itemClickedCommand ?? (itemClickedCommand = new Command((param) =>
        {
            if (!(param is TvItem item))
            {
                return;
            }

            ItemSelected(item.Id);
        }));

        private void ItemSelected(int id)
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

                    var tv = await tvService.GetTvDetailsAsync(id);

                    if (tv != null)
                    {
                        await Navigation.PushAsync(ViewContainer.Current.CreatePage(new TvDetailViewModel(tv)));
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

        private TvItem selectedItem;
        public TvItem SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;

                if (selectedItem != null)
                {
                    ItemSelected(selectedItem.Id);

                    SelectedItem = null;
                }
            }
        }

        private async Task LoadTvAsync()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;

                var popularTv = await tvService.GetPopularTvAsync();
                PopuplarTvFirst = popularTv != null ? new ObservableCollection<TvItem>(popularTv.Take(5)) : new ObservableCollection<TvItem>();
                PopuplarTvLast = popularTv != null ? new ObservableCollection<TvItem>(popularTv.Skip(5)) : new ObservableCollection<TvItem>();

                var onAir = await tvService.GetOnAirTvAsync();
                OnAirTv = onAir != null ? new ObservableCollection<TvItem>(onAir) : new ObservableCollection<TvItem>();

                var toprated = await tvService.GetTopRatedTvAsync();
                TopRatedTv = toprated != null ? new ObservableCollection<TvItem>(toprated) : new ObservableCollection<TvItem>();
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

        public ObservableCollection<TvItem> PopuplarTvFirst { get; set; }
        public ObservableCollection<TvItem> PopuplarTvLast { get; set; }
        public ObservableCollection<TvItem> OnAirTv { get; set; }
        public ObservableCollection<TvItem> TopRatedTv { get; set; }

        private readonly ITvService tvService;
    }
}
