﻿using Assisticant.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assisticant.Metas
{
    public class ObservableMeta : ValuePropertyMeta
    {
        ObservableMeta(MemberMeta observable, Type unwrappedType)
            : base(observable, unwrappedType)
        {
        }

        public override void SetValue(object instance, object value)
		{
            _valueProperty.SetValue(UnderlyingMember.GetValue(instance), value, null);
		}

        internal static MemberMeta Intercept(MemberMeta member)
        {
            var unwrapped = UnwrapObservableType(member.MemberType, typeof(Observable<>));
            if (unwrapped != null)
                return new ObservableMeta(member, unwrapped);
            else
                return member;
        }
    }
}
