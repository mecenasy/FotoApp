﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using FotoApp.Controls;
using FotoApp.Interface;
using FotoApp.Schell;
using FotoApp.Schell.EventArgs;

namespace FotoApp.ViewModels
{
    public class StartViewModel : PropertyChangedBase, ISchellable
    {
        public SchellViewModel Schell { get; set; }

        public delegate void OnCosingDelegate();

        public event OnCosingDelegate onClosing = null;
        #region Proportis

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(()=> CanBtnLogIn);
            }
        }

        #endregion

        #region Constractor
        public StartViewModel(SchellViewModel schell)
        {
            Schell = schell;

        }
        #endregion

        #region Actions

        public void BtnLogIn()
        {
            StartOrClose log = new StartOrClose();

            if (null == onClosing)
            {
                LogInHendler hendler = new LogInHendler();
                log.startOrCloseDelegate += hendler.StartOrClose;
                log.OnStart(Schell, Password);
            }
            else
            {
                OnColseHendler hendler = new OnColseHendler();
                log.startOrCloseDelegate += hendler.OnClosing;
                log.OnStart(null,Password);
            }
        }

        #endregion

        #region CanActions
        public bool CanBtnLogIn
        {
            get
            {
                return !string.IsNullOrEmpty(Password);
            }
        }
        #endregion

    }
}
