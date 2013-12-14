using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileBasedTrainingWindowsPhoneApp.Models;
using MobileBasedTrainingWindowsPhoneApp.Services;
using UpdateControls.Collections;
using UpdateControls.Fields;

namespace MobileBasedTrainingWindowsPhoneApp.ViewModels
{
    public class SearchViewModel
    {
        private readonly CourseService _courseService;

        private Independent<bool> _busy = new Independent<bool>();
        private Independent<List<Course>> _courses = new Independent<List<Course>>(new List<Course>());
        private Independent<string> _error = new Independent<string>();

        public SearchViewModel(CourseService courseService)
        {
            _courseService = courseService;
        }

        public bool Busy
        {
            get { return _busy.Value; }
        }

        public bool HasError
        {
            get { return !String.IsNullOrEmpty(_error.Value); }
        }

        public string Error
        {
            get { return _error.Value; }
        }

        public IEnumerable<Course> Courses
        {
            get { return _courses.Value; }
        }

        public async Task Search()
        {
            _busy.Value = true;
            _error.Value = null;
            try
            {
                _courses.Value = await _courseService.GetCoursesAsync();
            }
            catch (Exception ex)
            {
                _error.Value = ex.Message;
            }
            finally
            {
                _busy.Value = false;
            }
        }
    }
}
