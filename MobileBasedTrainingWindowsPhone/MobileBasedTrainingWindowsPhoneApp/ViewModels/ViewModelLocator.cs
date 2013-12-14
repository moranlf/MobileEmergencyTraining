using System;
using System.ComponentModel;
using System.Linq;
using UpdateControls.XAML;
using MobileBasedTrainingWindowsPhoneApp.Services;

namespace MobileBasedTrainingWindowsPhoneApp.ViewModels
{
    public class ViewModelLocator : ViewModelLocatorBase
    {
        private readonly SynchronizationService _synchronizationService;
        private readonly CourseService _courseService;

        public ViewModelLocator()
        {
            _synchronizationService = new SynchronizationService();
            if (!DesignerProperties.IsInDesignTool)
                _synchronizationService.Initialize();

            _courseService = new CourseService();
        }

        public object Main
        {
            get
            {
                return ViewModel(() => _synchronizationService.Individual == null
                    ? null :
                    new MainViewModel(
                        _synchronizationService.Community,
                        _synchronizationService.Individual));
            }
        }

        public object Search
        {
            get
            {
                return ViewModel(() => new SearchViewModel(_courseService));
            }
        }
    }
}
