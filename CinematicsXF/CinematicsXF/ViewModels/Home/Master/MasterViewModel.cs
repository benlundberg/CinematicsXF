﻿using System.Collections.Generic;
using System.Linq;
using CinematicsXF.Core;
using Xamarin.Forms;

namespace CinematicsXF
{
    public class MasterViewModel : BaseViewModel
    {
        public MasterViewModel(MasterDetailPage masterDetailPage)
        {
            Title = Device.RuntimePlatform == Device.iOS ? "☰" : AppConfig.AppName;

            this.masterDetailPage = masterDetailPage;

            if (Device.RuntimePlatform == Device.UWP)
            {
                masterDetailPage.MasterBehavior = MasterBehavior.Popover;
            }

            MasterItems = new List<MenuViewModel>()
            {
                // TODO: Add menu pages here
            };

            // TODO: If test you can add this log view
            if (true)
            {
                MasterItems.Add(new MenuViewModel()
                {
                    Title = Translate("Gen_Log"),
                    Page = new NavigationPage(ViewContainer.Current.CreatePage<LoggerViewModel>())
                });
            }

            ItemSelected(MasterItems.FirstOrDefault()?.Page);
        }

        private void ItemSelected(Page page)
        {
            if (page == null)
            {
                return;
            }

            masterDetailPage.Detail = page;
        }

        private MenuViewModel selectedMasterItem;
        public MenuViewModel SelectedMasterItem
        {
            get { return selectedMasterItem; }
            set
            {
                selectedMasterItem = value;

                if (selectedMasterItem != null)
                {
                    masterDetailPage.IsPresented = false;

                    ItemSelected(selectedMasterItem.Page);

                    SelectedMasterItem = null;
                }
            }
        }

        public List<MenuViewModel> MasterItems { get; private set; }

        public string Title { get; set; }

        private MasterDetailPage masterDetailPage;
    }
}
