// <copyright file="ViewModelBase.cs" company="Seorim Technology">
// Copyright (c) Seorim Technology. All rights reserved.
// </copyright>

namespace LSAMBeaconApp.Library
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// 뷰모델 클래스.
    /// </summary>
    [Serializable]
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// 프로퍼티의 값이 바뀔때의 이벤트 핸들러.
        /// </summary>
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 프로퍼티에서 Set연산을 처리.
        /// </summary>
        /// <typeparam name="T">자료형.</typeparam>
        /// <param name="member">멤버변수.</param>
        /// <param name="val">값.</param>
        /// <param name="propertyName">프로퍼티 명.</param>
        protected virtual void SetProperty<T>(ref T member, T val, [CallerMemberName] string propertyName = null)
        {
            // Check for current set member and the new value
            // If they are the same, do nothing
            if (object.Equals(member, val))
            {
                return;
            }

            member = val;

            // Invoke the property change event
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// PropertyChanged이벤트를 발생시키는 메소드.
        /// </summary>
        /// <param name="propertyName">프로퍼티 명.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
