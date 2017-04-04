﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FotoApp.Interface;
using FotoApp.Models;
using FotoApp.Schell;

namespace FotoApp.ViewModels
{
    public class GetFotoViewModel :Conductor<object>, ISchellable
    {
        public SchellViewModel Schell { get; set; }

        #region Delegate

        public delegate FinalColection FinalColectionDelegate();
        public delegate string ChangeName();
        public delegate string ChangePhone();
        public delegate string ChangeMail();

        public FinalColectionDelegate FinalColectionDelegat = null;
        public ChangeMail ChangeMailDelegate = null;
        public ChangeName ChangeNameDelegate = null;
        public ChangePhone ChangePhoneDelegate = null;

        #endregion

        #region  Propertis

        private string _price;
        private string _discount;
        private int _count = 12;
        private bool _closingOrder;
        private FinalColection _finalColection;
        public FinalColection FotoCollection
        {
            get { return _finalColection; }
            set
            {
                _finalColection = value;
                NotifyOfPropertyChange(() => FotoCollection);
            }
        }
        public string Price
        {
            get { return _price; }
            set
            {
                _price =  value;
                NotifyOfPropertyChange(() => Price);
            }
        }
        public string Discount
        {
            get { return _discount; }
            set
            {
                _discount =  value;
                NotifyOfPropertyChange(() => Discount);
            }
        }
        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                NotifyOfPropertyChange(() => Count);
            }
        }
        #endregion

        #region Constractor
        public GetFotoViewModel(SchellViewModel schell)
        {
            Schell = schell;
            FotoCollection = new FinalColection();

#if DEBUG
            _discount = "kjsdhsdkjfhsdkfs";
            _price = "klsdfjskdfhsdf";
#endif
        }
        #endregion

        #region  Actions
        public void Usb1()
        {
            ActivateItem(new ListFotoViewModel(Schell, this));
            _closingOrder = false;
        }
        public void Usb2()
        {
            ActivateItem(new ListFotoViewModel(Schell, this));
            _closingOrder = false;
        }
        public void Cd()
        {
            ActivateItem(new ListFotoViewModel(Schell, this));
            _closingOrder = false;
        }
        public void Cart()
        {
            ActivateItem(new ListFotoViewModel(Schell, this));
            _closingOrder = false;
        }
        public void Ok()
        {
            if (!_closingOrder)
            {
                ActivateItem(new ClosingOrderViewModel(Schell, this));
                FotoCollection = FinalColectionDelegat();
                _closingOrder = true;
            }
            else
            {  // wczytanie danych z do zatwierdzenia zlecenia 

                FotoCollection.CustomerName = ChangeNameDelegate();
                FotoCollection.CustomerMail = ChangeMailDelegate();
                FotoCollection.CustomerPhoneNumber = ChangePhoneDelegate();
                _closingOrder = false;
                // przesłanie zamuwieniea do bazy danych
                ActivateItem(null);
            }
        }
        #endregion

        #region CanActions
        public bool CanUsb1()
        {
            return true;
        }
        public bool CanUsb2()
        {
            return true;
        }
        public bool CanCd()
        {
            return true;
        }
        public bool CanCart()
        {
            return true;
        }

        public bool CanOk()
        {
            return true;
        }

        #endregion
    }
}
