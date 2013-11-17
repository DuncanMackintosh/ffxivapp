﻿// FFXIVAPP.Client
// HistoryViewModel.cs
// 
// © 2013 Ryan Wilson

#region Usings

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FFXIVAPP.Client.Plugins.Parse.Models;
using FFXIVAPP.Client.Plugins.Parse.Views;
using FFXIVAPP.Common.ViewModelBase;
using SmartAssembly.Attributes;

#endregion

namespace FFXIVAPP.Client.Plugins.Parse.ViewModels
{
    [DoNotObfuscate]
    internal sealed class HistoryViewModel : INotifyPropertyChanged
    {
        #region Property Bindings

        private static HistoryViewModel _instance;
        private ObservableCollection<ParseHistoryItem> _parseHistory;

        public static HistoryViewModel Instance
        {
            get { return _instance ?? (_instance = new HistoryViewModel()); }
        }

        public ObservableCollection<ParseHistoryItem> ParseHistory
        {
            get { return _parseHistory ?? (_parseHistory = new ObservableCollection<ParseHistoryItem>()); }
            set
            {
                if (_parseHistory == null)
                {
                    _parseHistory = new ObservableCollection<ParseHistoryItem>();
                }
                _parseHistory = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Declarations

        public ICommand LoadHistoryItemCommand { get; private set; }

        #endregion

        public HistoryViewModel()
        {
            LoadHistoryItemCommand = new DelegateCommand(LoadHistoryItem);
        }

        #region Loading Functions

        #endregion

        #region Utility Functions

        #endregion

        #region Command Bindings

        public void LoadHistoryItem()
        {
            var historyItem = ParseHistory[HistoryView.View.HistoryList.SelectedIndex].HistoryControl;
            HistoryControl.Instance.StatMonitor = historyItem.StatMonitor;
            HistoryControl.Instance.Timeline = historyItem.Timeline;
            HistoryControl.Instance.TimelineMonitor = historyItem.TimelineMonitor;
        }

        #endregion

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }

        #endregion
    }
}
