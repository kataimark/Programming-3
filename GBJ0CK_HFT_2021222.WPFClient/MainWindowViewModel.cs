﻿using GBJ0CK_HFT_2021222.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GBJ0CK_HFT_2021222.WPFClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<LolManager> LolManagers { get; set; }
        public RestCollection<LolTeam> LolTeams { get; set; }
        public RestCollection<LolPlayer> LolPlayers { get; set; }

        private LolManager selectedLolManager;
        private LolTeam selectedLolTeam;
        private LolPlayer selectedLolPlayer;

        
        

        public LolManager SelectedLolManager
        {
            get { return selectedLolManager; }
            set
            {
                if (value != null)
                {
                    selectedLolManager = new LolManager()
                    {
                        Id = value.Id,
                        ManagerName = value.ManagerName,
                        Age = value.Age

                    };
                    OnPropertyChanged();
                    (DeleteLolManager as RelayCommand).NotifyCanExecuteChanged();
                    //(UpdateLolManager as RelayCommand).NotifyCanExecuteChanged();
                }
               

            }
        }
        public LolTeam SelectedLolTeam
        {
            get => selectedLolTeam;
            set
            {
                if (value != null)
                {
                    selectedLolTeam = new LolTeam()
                    {
                        Id = value.Id,
                        TeamName = value.TeamName,
                        Wins = value.Wins,
                        LolManager_id = value.LolManager_id
                       

                    };
                    OnPropertyChanged();
                    (DeleteLolTeam as RelayCommand).NotifyCanExecuteChanged();
                    //(UpdateLolTeam as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public LolPlayer SelectedLolPlayer
        {
            get => selectedLolPlayer;
            set
            {
                if (value != null)
                {
                    selectedLolPlayer = new LolPlayer()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Age = value.Age,
                        LolTeam_id = value.LolTeam_id

                    };
                    OnPropertyChanged();
                    (DeleteLolPlayer as RelayCommand).NotifyCanExecuteChanged();
                    //(UpdateLolPlayer as RelayCommand).NotifyCanExecuteChanged();
                    
                }
            }
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public ICommand CreateLolManager { get; set; }
        public ICommand UpdateLolManager { get; set; }
        public ICommand DeleteLolManager { get; set; }

        public ICommand CreateLolTeam { get; set; }
        public ICommand UpdateLolTeam { get; set; }
        public ICommand DeleteLolTeam { get; set; }

        public ICommand CreateLolPlayer { get; set; }
        public ICommand UpdateLolPlayer { get; set; }
        public ICommand DeleteLolPlayer { get; set; }
        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                LolManagers = new RestCollection<LolManager>("http://localhost:48540/", "LolManager","hub");
                CreateLolManager = new RelayCommand(() =>
                {
                    LolManagers.Add(new LolManager()
                    {

                        ManagerName = SelectedLolManager.ManagerName,
                        Age = SelectedLolManager.Age

                    });
                });
                UpdateLolManager = new RelayCommand(() => LolManagers.Update(SelectedLolManager));
                DeleteLolManager = new RelayCommand(() => LolManagers.Delete(SelectedLolManager.Id), () => SelectedLolManager != null);
                SelectedLolManager = new LolManager();

                //---------------------------------------------------------------
                LolTeams = new RestCollection<LolTeam>("http://localhost:48540/", "LolTeam","hub");
                CreateLolTeam = new RelayCommand(() =>
                {
                    LolTeams.Add(new LolTeam()
                    {

                        
                        TeamName = SelectedLolTeam.TeamName,
                        Wins = SelectedLolTeam.Wins,
                        LolManager_id = SelectedLolTeam.LolManager_id

                    });
                });
                UpdateLolTeam = new RelayCommand(() => LolTeams.Update(SelectedLolTeam));
                DeleteLolTeam = new RelayCommand(() => LolTeams.Delete(SelectedLolTeam.Id), () => SelectedLolTeam != null);
                SelectedLolTeam = new LolTeam();

                //---------------------------------------------------------------
                LolPlayers = new RestCollection<LolPlayer>("http://localhost:48540/", "LolPlayer","hub");
                CreateLolPlayer = new RelayCommand(() =>
                {
                    LolPlayers.Add(new LolPlayer()
                    {

                        Name = SelectedLolPlayer.Name,
                        Age = SelectedLolPlayer.Age,
                        LolTeam_id = SelectedLolPlayer.LolTeam_id

                    }) ;
                });
                UpdateLolPlayer = new RelayCommand(() => LolPlayers.Update(SelectedLolPlayer));
                DeleteLolPlayer = new RelayCommand(() => LolPlayers.Delete(SelectedLolPlayer.Id), () => SelectedLolPlayer != null);
                SelectedLolPlayer = new LolPlayer();

            }


        }


    }
}
