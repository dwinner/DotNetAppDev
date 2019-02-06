﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
namespace Company.DSLSample
{
	/// <summary>
	/// DomainClass ExampleModel
	/// The root in which all other elements are embedded. Appears as a diagram.
	/// </summary>
	[DslDesign::DisplayNameResource("Company.DSLSample.ExampleModel.DisplayName", typeof(global::Company.DSLSample.DSLSampleDomainModel), "Company.DSLSample.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Company.DSLSample.ExampleModel.Description", typeof(global::Company.DSLSample.DSLSampleDomainModel), "Company.DSLSample.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Company.DSLSample.DSLSampleDomainModel))]
	[global::System.CLSCompliant(true)]
	[DslModeling::DomainObjectId("79000270-d182-4de5-964f-2f19cbc9afd4")]
	public partial class ExampleModel : DslModeling::ModelElement
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// ExampleModel domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new global::System.Guid(0x79000270, 0xd182, 0x4de5, 0x96, 0x4f, 0x2f, 0x19, 0xcb, 0xc9, 0xaf, 0xd4);
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ExampleModel(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ExampleModel(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		#region Elements opposite domain role accessor
		
		/// <summary>
		/// Gets a list of Elements.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<ExampleElement> Elements
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<ExampleElement>, ExampleElement>(global::Company.DSLSample.ExampleModelHasElements.ExampleModelDomainRoleId);
			}
		}
		#endregion
		#region ElementGroupPrototype Merge methods
		/// <summary>
		/// Returns a value indicating whether the source element represented by the
		/// specified root ProtoElement can be added to this element.
		/// </summary>
		/// <param name="rootElement">
		/// The root ProtoElement representing a source element.  This can be null, 
		/// in which case the ElementGroupPrototype does not contain an ProtoElements
		/// and the code should inspect the ElementGroupPrototype context information.
		/// </param>
		/// <param name="elementGroupPrototype">The ElementGroupPrototype that contains the root ProtoElement.</param>
		/// <returns>true if the source element represented by the ProtoElement can be added to this target element.</returns>
		protected override bool CanMerge(DslModeling::ProtoElementBase rootElement, DslModeling::ElementGroupPrototype elementGroupPrototype)
		{
			if ( elementGroupPrototype == null ) throw new global::System.ArgumentNullException("elementGroupPrototype");
			
			if (rootElement != null)
			{
				DslModeling::DomainClassInfo rootElementDomainInfo = this.Partition.DomainDataDirectory.GetDomainClass(rootElement.DomainClassId);
				
				if (rootElementDomainInfo.IsDerivedFrom(global::Company.DSLSample.ExampleElement.DomainClassId)) 
				{
					return true;
				}
			}
			return base.CanMerge(rootElement, elementGroupPrototype);
		}
		
		/// <summary>
		/// Called by the Merge process to create a relationship between 
		/// this target element and the specified source element. 
		/// Typically, a parent-child relationship is established
		/// between the target element (the parent) and the source element 
		/// (the child), but any relationship can be established.
		/// </summary>
		/// <param name="sourceElement">The element that is to be related to this model element.</param>
		/// <param name="elementGroup">The group of source ModelElements that have been rehydrated into the target store.</param>
		/// <remarks>
		/// This method is overriden to create the relationship between the target element and the specified source element.
		/// The base method does nothing.
		/// </remarks>
		protected override void MergeRelate(DslModeling::ModelElement sourceElement, DslModeling::ElementGroup elementGroup)
		{
			// In general, sourceElement is allowed to be null, meaning that the elementGroup must be parsed for special cases.
			// However this is not supported in generated code.  Use double-deriving on this class and then override MergeRelate completely if you 
			// need to support this case.
			if ( sourceElement == null ) throw new global::System.ArgumentNullException("sourceElement");
		
				
			global::Company.DSLSample.ExampleElement sourceExampleElement1 = sourceElement as global::Company.DSLSample.ExampleElement;
			if (sourceExampleElement1 != null)
			{
				// Create link for path ExampleModelHasElements.Elements
				this.Elements.Add(sourceExampleElement1);

				return;
			}
		
			// Sdk workaround to runtime bug #879350 (DSL: can't copy and paste a MEL that has a MEX). Avoid MergeRelate on ModelElementExtension
			// during a "Paste".
			if (sourceElement is DslModeling::ExtensionElement
				&& sourceElement.Store.TransactionManager.CurrentTransaction.TopLevelTransaction.Context.ContextInfo.ContainsKey("{9DAFD42A-DC0E-4d78-8C3F-8266B2CF8B33}"))
			{
				return;
			}
		
			// Fall through to base class if this class hasn't handled the merge.
			base.MergeRelate(sourceElement, elementGroup);
		}
		
		/// <summary>
		/// Performs operation opposite to MergeRelate - i.e. disconnects a given
		/// element from the current one (removes links created by MergeRelate).
		/// </summary>
		/// <param name="sourceElement">Element to be unmerged/disconnected.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		protected override void MergeDisconnect(DslModeling::ModelElement sourceElement)
		{
			if (sourceElement == null) throw new global::System.ArgumentNullException("sourceElement");
				
			global::Company.DSLSample.ExampleElement sourceExampleElement1 = sourceElement as global::Company.DSLSample.ExampleElement;
			if (sourceExampleElement1 != null)
			{
				// Delete link for path ExampleModelHasElements.Elements
				
				foreach (DslModeling::ElementLink link in global::Company.DSLSample.ExampleModelHasElements.GetLinks((global::Company.DSLSample.ExampleModel)this, sourceExampleElement1))
				{
					// Delete the link, but without possible delete propagation to the element since it's moving to a new location.
					link.Delete(global::Company.DSLSample.ExampleModelHasElements.ExampleModelDomainRoleId, global::Company.DSLSample.ExampleModelHasElements.ElementDomainRoleId);
				}

				return;
			}
			// Fall through to base class if this class hasn't handled the unmerge.
			base.MergeDisconnect(sourceElement);
		}
		#endregion
	}
}
namespace Company.DSLSample
{
	/// <summary>
	/// DomainClass ExampleElement
	/// Elements embedded in the model. Appear as boxes on the diagram.
	/// </summary>
	[DslDesign::DisplayNameResource("Company.DSLSample.ExampleElement.DisplayName", typeof(global::Company.DSLSample.DSLSampleDomainModel), "Company.DSLSample.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Company.DSLSample.ExampleElement.Description", typeof(global::Company.DSLSample.DSLSampleDomainModel), "Company.DSLSample.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Company.DSLSample.DSLSampleDomainModel))]
	[global::System.CLSCompliant(true)]
	[global::System.Diagnostics.DebuggerDisplay("{GetType().Name,nq} (Name = {namePropertyStorage})")]
	[DslModeling::DomainObjectId("bdb663a9-9fa6-4dbb-8b10-9f6589fd5da7")]
	public partial class ExampleElement : DslModeling::ModelElement
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// ExampleElement domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new global::System.Guid(0xbdb663a9, 0x9fa6, 0x4dbb, 0x8b, 0x10, 0x9f, 0x65, 0x89, 0xfd, 0x5d, 0xa7);
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ExampleElement(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ExampleElement(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		#region Name domain property code
		
		/// <summary>
		/// Name domain property Id.
		/// </summary>
		public static readonly global::System.Guid NameDomainPropertyId = new global::System.Guid(0x2927911d, 0x79be, 0x4f23, 0xa6, 0x10, 0x76, 0x4e, 0x46, 0x9d, 0xf2, 0x8f);
		
		/// <summary>
		/// Storage for Name
		/// </summary>
		private global::System.String namePropertyStorage = string.Empty;
		
		/// <summary>
		/// Gets or sets the value of Name domain property.
		/// Description for Company.DSLSample.ExampleElement.Name
		/// </summary>
		[DslDesign::DisplayNameResource("Company.DSLSample.ExampleElement/Name.DisplayName", typeof(global::Company.DSLSample.DSLSampleDomainModel), "Company.DSLSample.GeneratedCode.DomainModelResx")]
		[DslDesign::DescriptionResource("Company.DSLSample.ExampleElement/Name.Description", typeof(global::Company.DSLSample.DSLSampleDomainModel), "Company.DSLSample.GeneratedCode.DomainModelResx")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::ElementName]
		[DslModeling::DomainObjectId("2927911d-79be-4f23-a610-764e469df28f")]
		public global::System.String Name
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return namePropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				NamePropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the ExampleElement.Name domain property.
		/// </summary>
		internal sealed partial class NamePropertyHandler : DslModeling::DomainPropertyValueHandler<ExampleElement, global::System.String>
		{
			private NamePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the ExampleElement.Name domain property value handler.
			/// </summary>
			public static readonly NamePropertyHandler Instance = new NamePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the ExampleElement.Name domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return NameDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::System.String GetValue(ExampleElement element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.namePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(ExampleElement element, global::System.String newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::System.String oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.namePropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region ExampleModel opposite domain role accessor
		/// <summary>
		/// Gets or sets ExampleModel.
		/// </summary>
		public virtual ExampleModel ExampleModel
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Company.DSLSample.ExampleModelHasElements.ElementDomainRoleId) as ExampleModel;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Company.DSLSample.ExampleModelHasElements.ElementDomainRoleId, value);
			}
		}
		#endregion
		#region Targets opposite domain role accessor
		
		/// <summary>
		/// Gets a list of Targets.
		/// Description for Company.DSLSample.ExampleRelationship.Target
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<ExampleElement> Targets
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<ExampleElement>, ExampleElement>(global::Company.DSLSample.ExampleElementReferencesTargets.SourceDomainRoleId);
			}
		}
		#endregion
		#region Sources opposite domain role accessor
		
		/// <summary>
		/// Gets a list of Sources.
		/// Description for Company.DSLSample.ExampleRelationship.Source
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<ExampleElement> Sources
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<ExampleElement>, ExampleElement>(global::Company.DSLSample.ExampleElementReferencesTargets.TargetDomainRoleId);
			}
		}
		#endregion
	}
}
