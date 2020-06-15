//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using NMF.Collections.Generic;
using NMF.Collections.ObjectModel;
using NMF.Expressions;
using NMF.Expressions.Linq;
using NMF.Models;
using NMF.Models.Collections;
using NMF.Models.Expressions;
using NMF.Models.Meta;
using NMF.Models.Repository;
using NMF.Serialization;
using NMF.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace TTC2020.Roundtrip.Scenario4.V1.Model
{
    
    
    /// <summary>
    /// The public interface for Dog
    /// </summary>
    [DefaultImplementationTypeAttribute(typeof(Dog))]
    [XmlDefaultImplementationTypeAttribute(typeof(Dog))]
    [ModelRepresentationClassAttribute("http://ttc2020/model/scenario4/1.0#//Dog")]
    public interface IDog : IModelElement
    {
        
        /// <summary>
        /// The name property
        /// </summary>
        [DisplayNameAttribute("name")]
        [CategoryAttribute("Dog")]
        [XmlElementNameAttribute("name")]
        [IdAttribute()]
        [XmlAttributeAttribute(true)]
        string Name
        {
            get;
            set;
        }
        
        /// <summary>
        /// The age property
        /// </summary>
        [DisplayNameAttribute("age")]
        [CategoryAttribute("Dog")]
        [XmlElementNameAttribute("age")]
        [XmlAttributeAttribute(true)]
        int Age
        {
            get;
            set;
        }
        
        /// <summary>
        /// The owner property
        /// </summary>
        [DisplayNameAttribute("owner")]
        [CategoryAttribute("Dog")]
        [XmlElementNameAttribute("owner")]
        [XmlAttributeAttribute(true)]
        IPerson Owner
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets fired before the Name property changes its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> NameChanging;
        
        /// <summary>
        /// Gets fired when the Name property changed its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> NameChanged;
        
        /// <summary>
        /// Gets fired before the Age property changes its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> AgeChanging;
        
        /// <summary>
        /// Gets fired when the Age property changed its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> AgeChanged;
        
        /// <summary>
        /// Gets fired before the Owner property changes its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> OwnerChanging;
        
        /// <summary>
        /// Gets fired when the Owner property changed its value
        /// </summary>
        event System.EventHandler<ValueChangedEventArgs> OwnerChanged;
    }
}
