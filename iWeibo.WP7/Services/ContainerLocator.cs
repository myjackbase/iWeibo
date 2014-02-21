﻿using Funq;
using iWeibo.WP7.Adapters;
using iWeibo.WP7.ViewModels;
using iWeibo.WP7.ViewModels.TencentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace iWeibo.WP7.Services
{
    public class ContainerLocator:IDisposable
    {
        private bool disposed;

        public ContainerLocator()
        {
            this.Container = new Container();
            this.ConfigureContainer();
        }

        public Container Container { get; private set; }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
                return;
            if (disposing)
                this.Container.Dispose();

            this.disposed = true;
        }


        private void ConfigureContainer()
        {
            this.Container.Register<IPhoneApplicationServiceFacade>(c => new PhoneApplicationServiceFacade());
            this.Container.Register<INavigationService>(c => new ApplicationFrameNavigationService(((App)Application.Current).RootFrame));
            this.Container.Register<IMessageBox>(c => new MessageBoxAdapter());
            this.Container.Register<IPhotoChooserTask>(c => new PhotoChooserTaskAdapter());

            //View Model
            this.Container.Register(
                c => new MainPageViewModel(
                    c.Resolve<INavigationService>(),
                    c.Resolve<IPhoneApplicationServiceFacade>()));

            this.Container.Register(
                c => new TencentTimelineViewModel(
                    c.Resolve<INavigationService>(),
                    c.Resolve<IPhoneApplicationServiceFacade>()));

            this.Container.Register(
                c => new PostNewViewModel(
                    c.Resolve<INavigationService>(),
                    c.Resolve<IPhoneApplicationServiceFacade>(),
                    c.Resolve<IPhotoChooserTask>(),
                    c.Resolve<IMessageBox>()));

        }

    }
}