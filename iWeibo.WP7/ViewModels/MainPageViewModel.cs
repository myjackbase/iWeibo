﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using iWeibo.WP7.Adapters;
using iWeibo.WP7.Models.SinaModels;
using iWeibo.WP7.Models.TencentModels;
using iWeibo.WP7.Services;
using TencentWeiboSDK.Model;

namespace iWeibo.WP7.ViewModels
{
    public class MainPageViewModel:ViewModel
    {
        public DelegateCommand EnterSinaCommand { get; set; }
        public DelegateCommand EnterTencentCommand { get; set; }
        public DelegateCommand EnterPostNewCommand { get; set; }
        //public DelegateCommand BackKeyPressCommand { get; set; }

        public MainPageViewModel(
            INavigationService navigationService,
            IPhoneApplicationServiceFacade phoneApplicationFacade)
            :base(navigationService,phoneApplicationFacade,new Uri(Constants.MainPageView,UriKind.Relative))
        {
            EnterSinaCommand = new DelegateCommand(EnterSina);
            EnterTencentCommand = new DelegateCommand(EnterTencent);
            EnterPostNewCommand = new DelegateCommand(EnterPostNew);
            //BackKeyPressCommand = new DelegateCommand(OnBackKeyPress);
        }

        private void EnterSina()
        {
            if (SinaConfig.Validate())
            {
                this.NavigationService.Navigate(new Uri(Constants.SinaTimelineView, UriKind.Relative));
            }
            else
            {
                this.NavigationService.Navigate(new Uri(Constants.SinaLoginView, UriKind.Relative));
            }
        }

        private void EnterTencent()
        {
            if (TencentConfig.Validate())
            {
                TencentWeiboSDK.OAuthConfigruation.AccessToken = TokenIsoStorage.TencentTokenStorage.LoadData<TencentAccessToken>();
                this.NavigationService.Navigate(new Uri(Constants.TencentTimelineView, UriKind.Relative));
            }
            else
            {
                this.NavigationService.Navigate(new Uri(Constants.TencentLoginView, UriKind.Relative));
            }
        }

        private void EnterPostNew()
        {
            this.NavigationService.Navigate(new Uri(Constants.PostNewView, UriKind.Relative));
        }

        //private bool leaving = false;

        //private void OnBackKeyPress()
        //{

        //}

        public override void OnPageResumeFromTombstoning()
        {
            //throw new NotImplementedException();
        }
    }
}
