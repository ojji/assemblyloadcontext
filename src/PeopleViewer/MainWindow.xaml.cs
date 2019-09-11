using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using PeopleRepository.Interface;
using PeopleViewer.Annotations;

namespace PeopleViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;
        }

        private void FetchButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.FetchData();
        }

        private void ClearDataButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ClearData();
        }
    }

    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IPeopleRepository _peopleRepository;

        private IEnumerable<Person> _people = new List<Person>();
        public IEnumerable<Person> People
        {
            get => _people;
            set
            {
                _people = value;
                OnPropertyChanged();
            }
        }
        
        public MainViewModel()
        {
            _peopleRepository = RepositoryFactory.CreateRepository();
        }

        public void FetchData()
        {
            People = _peopleRepository.GetPeople();
        }

        public void ClearData()
        {
            People = new List<Person>();
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}
