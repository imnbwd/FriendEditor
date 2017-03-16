using GalaSoft.MvvmLight.Ioc;
using System;

namespace FriendEditor.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<EditViewModel>();
        }

        public EditViewModel EditViewModel => SimpleIoc.Default.GetInstance<EditViewModel>(Guid.NewGuid().ToString());
        public MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>(Guid.NewGuid().ToString());
    }
}