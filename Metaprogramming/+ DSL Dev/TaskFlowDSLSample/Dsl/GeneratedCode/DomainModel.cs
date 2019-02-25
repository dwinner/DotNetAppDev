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
using DslDiagrams = global::Microsoft.VisualStudio.Modeling.Diagrams;
namespace AppDevUnited.TaskFlowDSLSample
{
	/// <summary>
	/// DomainModel TaskFlowDSLSampleDomainModel
	/// Description for AppDevUnited.TaskFlowDSLSample.TaskFlowDSLSample
	/// </summary>
	[DslDesign::DisplayNameResource("AppDevUnited.TaskFlowDSLSample.TaskFlowDSLSampleDomainModel.DisplayName", typeof(global::AppDevUnited.TaskFlowDSLSample.TaskFlowDSLSampleDomainModel), "AppDevUnited.TaskFlowDSLSample.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("AppDevUnited.TaskFlowDSLSample.TaskFlowDSLSampleDomainModel.Description", typeof(global::AppDevUnited.TaskFlowDSLSample.TaskFlowDSLSampleDomainModel), "AppDevUnited.TaskFlowDSLSample.GeneratedCode.DomainModelResx")]
	[global::System.CLSCompliant(true)]
	[DslModeling::DependsOnDomainModel(typeof(global::Microsoft.VisualStudio.Modeling.CoreDomainModel))]
	[DslModeling::DependsOnDomainModel(typeof(global::Microsoft.VisualStudio.Modeling.Diagrams.CoreDesignSurfaceDomainModel))]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]
	[DslModeling::DomainObjectId("57dcda11-0ca5-4bfe-85c7-9fb8be4810cc")]
	public partial class TaskFlowDSLSampleDomainModel : DslModeling::DomainModel
	{
		#region Constructor, domain model Id
	
		/// <summary>
		/// TaskFlowDSLSampleDomainModel domain model Id.
		/// </summary>
		public static readonly global::System.Guid DomainModelId = new global::System.Guid(0x57dcda11, 0x0ca5, 0x4bfe, 0x85, 0xc7, 0x9f, 0xb8, 0xbe, 0x48, 0x10, 0xcc);
	
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="store">Store containing the domain model.</param>
		public TaskFlowDSLSampleDomainModel(DslModeling::Store store)
			: base(store, DomainModelId)
		{
			// Call the partial method to allow any required serialization setup to be done.
			this.InitializeSerialization(store);		
		}
		
	
		///<Summary>
		/// Defines a partial method that will be called from the constructor to
		/// allow any necessary serialization setup to be done.
		///</Summary>
		///<remarks>
		/// For a DSL created with the DSL Designer wizard, an implementation of this 
		/// method will be generated in the GeneratedCode\SerializationHelper.cs class.
		///</remarks>
		partial void InitializeSerialization(DslModeling::Store store);
	
	
		#endregion
		#region Domain model reflection
			
		/// <summary>
		/// Gets the list of generated domain model types (classes, rules, relationships).
		/// </summary>
		/// <returns>List of types.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]	
		protected sealed override global::System.Type[] GetGeneratedDomainModelTypes()
		{
			return new global::System.Type[]
			{
				typeof(NamedElement),
				typeof(FlowGraph),
				typeof(FlowElement),
				typeof(ObjectFlowElement),
				typeof(Task),
				typeof(StartPoint),
				typeof(Endpoint),
				typeof(MergeBranch),
				typeof(Synchronization),
				typeof(ObjectInState),
				typeof(Comment),
				typeof(Actor),
				typeof(Flow),
				typeof(FlowGraphHasComments),
				typeof(FlowGraphHasActors),
				typeof(CommentReferencesSubjects),
				typeof(ObjectFlow),
				typeof(ActorHasFlowElements),
				typeof(TaskFlowDSLSampleDiagram),
				typeof(CommentConnector),
				typeof(FlowConnector),
				typeof(ObjectFlowConnector),
				typeof(ActorSwimLane),
				typeof(TaskShape),
				typeof(CommentBoxShape),
				typeof(SyncBarShape),
				typeof(ObjectShape),
				typeof(MergeBranchShape),
				typeof(EndShape),
				typeof(StartShape),
				typeof(global::AppDevUnited.TaskFlowDSLSample.FixUpDiagram),
				typeof(global::AppDevUnited.TaskFlowDSLSample.DecoratorPropertyChanged),
				typeof(global::AppDevUnited.TaskFlowDSLSample.ConnectorRolePlayerChanged),
			};
		}
		/// <summary>
		/// Gets the list of generated domain properties.
		/// </summary>
		/// <returns>List of property data.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]	
		protected sealed override DomainMemberInfo[] GetGeneratedDomainProperties()
		{
			return new DomainMemberInfo[]
			{
				new DomainMemberInfo(typeof(NamedElement), "Name", NamedElement.NameDomainPropertyId, typeof(NamedElement.NamePropertyHandler)),
				new DomainMemberInfo(typeof(FlowElement), "Description", FlowElement.DescriptionDomainPropertyId, typeof(FlowElement.DescriptionPropertyHandler)),
				new DomainMemberInfo(typeof(Task), "NestedDiagram", Task.NestedDiagramDomainPropertyId, typeof(Task.NestedDiagramPropertyHandler)),
				new DomainMemberInfo(typeof(Task), "Sort", Task.SortDomainPropertyId, typeof(Task.SortPropertyHandler)),
				new DomainMemberInfo(typeof(ObjectInState), "State", ObjectInState.StateDomainPropertyId, typeof(ObjectInState.StatePropertyHandler)),
				new DomainMemberInfo(typeof(Comment), "Text", Comment.TextDomainPropertyId, typeof(Comment.TextPropertyHandler)),
				new DomainMemberInfo(typeof(Flow), "Guard", Flow.GuardDomainPropertyId, typeof(Flow.GuardPropertyHandler)),
			};
		}
		/// <summary>
		/// Gets the list of generated domain roles.
		/// </summary>
		/// <returns>List of role data.</returns>
		protected sealed override DomainRolePlayerInfo[] GetGeneratedDomainRoles()
		{
			return new DomainRolePlayerInfo[]
			{
				new DomainRolePlayerInfo(typeof(Flow), "FlowFrom", Flow.FlowFromDomainRoleId),
				new DomainRolePlayerInfo(typeof(Flow), "FlowTo", Flow.FlowToDomainRoleId),
				new DomainRolePlayerInfo(typeof(FlowGraphHasComments), "FlowGraph", FlowGraphHasComments.FlowGraphDomainRoleId),
				new DomainRolePlayerInfo(typeof(FlowGraphHasComments), "Comment", FlowGraphHasComments.CommentDomainRoleId),
				new DomainRolePlayerInfo(typeof(FlowGraphHasActors), "FlowGraph", FlowGraphHasActors.FlowGraphDomainRoleId),
				new DomainRolePlayerInfo(typeof(FlowGraphHasActors), "Actor", FlowGraphHasActors.ActorDomainRoleId),
				new DomainRolePlayerInfo(typeof(CommentReferencesSubjects), "Comment", CommentReferencesSubjects.CommentDomainRoleId),
				new DomainRolePlayerInfo(typeof(CommentReferencesSubjects), "Subject", CommentReferencesSubjects.SubjectDomainRoleId),
				new DomainRolePlayerInfo(typeof(ObjectFlow), "ObjectFlowTo", ObjectFlow.ObjectFlowToDomainRoleId),
				new DomainRolePlayerInfo(typeof(ObjectFlow), "ObjectFlowFrom", ObjectFlow.ObjectFlowFromDomainRoleId),
				new DomainRolePlayerInfo(typeof(ActorHasFlowElements), "Actor", ActorHasFlowElements.ActorDomainRoleId),
				new DomainRolePlayerInfo(typeof(ActorHasFlowElements), "FlowElement", ActorHasFlowElements.FlowElementDomainRoleId),
			};
		}
		#endregion
		#region Factory methods
		private static global::System.Collections.Generic.Dictionary<global::System.Type, int> createElementMap;
	
		/// <summary>
		/// Creates an element of specified type.
		/// </summary>
		/// <param name="partition">Partition where element is to be created.</param>
		/// <param name="elementType">Element type which belongs to this domain model.</param>
		/// <param name="propertyAssignments">New element property assignments.</param>
		/// <returns>Created element.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]	
		public sealed override DslModeling::ModelElement CreateElement(DslModeling::Partition partition, global::System.Type elementType, DslModeling::PropertyAssignment[] propertyAssignments)
		{
			if (elementType == null) throw new global::System.ArgumentNullException("elementType");
	
			if (createElementMap == null)
			{
				createElementMap = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(24);
				createElementMap.Add(typeof(FlowGraph), 0);
				createElementMap.Add(typeof(Task), 1);
				createElementMap.Add(typeof(StartPoint), 2);
				createElementMap.Add(typeof(Endpoint), 3);
				createElementMap.Add(typeof(MergeBranch), 4);
				createElementMap.Add(typeof(Synchronization), 5);
				createElementMap.Add(typeof(ObjectInState), 6);
				createElementMap.Add(typeof(Comment), 7);
				createElementMap.Add(typeof(Actor), 8);
				createElementMap.Add(typeof(TaskFlowDSLSampleDiagram), 9);
				createElementMap.Add(typeof(CommentConnector), 10);
				createElementMap.Add(typeof(FlowConnector), 11);
				createElementMap.Add(typeof(ObjectFlowConnector), 12);
				createElementMap.Add(typeof(ActorSwimLane), 13);
				createElementMap.Add(typeof(TaskShape), 14);
				createElementMap.Add(typeof(CommentBoxShape), 15);
				createElementMap.Add(typeof(SyncBarShape), 16);
				createElementMap.Add(typeof(ObjectShape), 17);
				createElementMap.Add(typeof(MergeBranchShape), 18);
				createElementMap.Add(typeof(EndShape), 19);
				createElementMap.Add(typeof(StartShape), 20);
			}
			int index;
			if (!createElementMap.TryGetValue(elementType, out index))
			{
				// construct exception error message		
				string exceptionError = string.Format(
								global::System.Globalization.CultureInfo.CurrentCulture,
								global::AppDevUnited.TaskFlowDSLSample.TaskFlowDSLSampleDomainModel.SingletonResourceManager.GetString("UnrecognizedElementType"),
								elementType.Name);
				throw new global::System.ArgumentException(exceptionError, "elementType");
			}
			switch (index)
			{
				case 0: return new FlowGraph(partition, propertyAssignments);
				case 1: return new Task(partition, propertyAssignments);
				case 2: return new StartPoint(partition, propertyAssignments);
				case 3: return new Endpoint(partition, propertyAssignments);
				case 4: return new MergeBranch(partition, propertyAssignments);
				case 5: return new Synchronization(partition, propertyAssignments);
				case 6: return new ObjectInState(partition, propertyAssignments);
				case 7: return new Comment(partition, propertyAssignments);
				case 8: return new Actor(partition, propertyAssignments);
				case 9: return new TaskFlowDSLSampleDiagram(partition, propertyAssignments);
				case 10: return new CommentConnector(partition, propertyAssignments);
				case 11: return new FlowConnector(partition, propertyAssignments);
				case 12: return new ObjectFlowConnector(partition, propertyAssignments);
				case 13: return new ActorSwimLane(partition, propertyAssignments);
				case 14: return new TaskShape(partition, propertyAssignments);
				case 15: return new CommentBoxShape(partition, propertyAssignments);
				case 16: return new SyncBarShape(partition, propertyAssignments);
				case 17: return new ObjectShape(partition, propertyAssignments);
				case 18: return new MergeBranchShape(partition, propertyAssignments);
				case 19: return new EndShape(partition, propertyAssignments);
				case 20: return new StartShape(partition, propertyAssignments);
				default: return null;
			}
		}
	
		private static global::System.Collections.Generic.Dictionary<global::System.Type, int> createElementLinkMap;
	
		/// <summary>
		/// Creates an element link of specified type.
		/// </summary>
		/// <param name="partition">Partition where element is to be created.</param>
		/// <param name="elementLinkType">Element link type which belongs to this domain model.</param>
		/// <param name="roleAssignments">List of relationship role assignments for the new link.</param>
		/// <param name="propertyAssignments">New element property assignments.</param>
		/// <returns>Created element link.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		public sealed override DslModeling::ElementLink CreateElementLink(DslModeling::Partition partition, global::System.Type elementLinkType, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
		{
			if (elementLinkType == null) throw new global::System.ArgumentNullException("elementLinkType");
			if (roleAssignments == null) throw new global::System.ArgumentNullException("roleAssignments");
	
			if (createElementLinkMap == null)
			{
				createElementLinkMap = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(6);
				createElementLinkMap.Add(typeof(Flow), 0);
				createElementLinkMap.Add(typeof(FlowGraphHasComments), 1);
				createElementLinkMap.Add(typeof(FlowGraphHasActors), 2);
				createElementLinkMap.Add(typeof(CommentReferencesSubjects), 3);
				createElementLinkMap.Add(typeof(ObjectFlow), 4);
				createElementLinkMap.Add(typeof(ActorHasFlowElements), 5);
			}
			int index;
			if (!createElementLinkMap.TryGetValue(elementLinkType, out index))
			{
				// construct exception error message
				string exceptionError = string.Format(
								global::System.Globalization.CultureInfo.CurrentCulture,
								global::AppDevUnited.TaskFlowDSLSample.TaskFlowDSLSampleDomainModel.SingletonResourceManager.GetString("UnrecognizedElementLinkType"),
								elementLinkType.Name);
				throw new global::System.ArgumentException(exceptionError, "elementLinkType");
			
			}
			switch (index)
			{
				case 0: return new Flow(partition, roleAssignments, propertyAssignments);
				case 1: return new FlowGraphHasComments(partition, roleAssignments, propertyAssignments);
				case 2: return new FlowGraphHasActors(partition, roleAssignments, propertyAssignments);
				case 3: return new CommentReferencesSubjects(partition, roleAssignments, propertyAssignments);
				case 4: return new ObjectFlow(partition, roleAssignments, propertyAssignments);
				case 5: return new ActorHasFlowElements(partition, roleAssignments, propertyAssignments);
				default: return null;
			}
		}
		#endregion
		#region Resource manager
		
		private static global::System.Resources.ResourceManager resourceManager;
		
		/// <summary>
		/// The base name of this model's resources.
		/// </summary>
		public const string ResourceBaseName = "AppDevUnited.TaskFlowDSLSample.GeneratedCode.DomainModelResx";
		
		/// <summary>
		/// Gets the DomainModel's ResourceManager. If the ResourceManager does not already exist, then it is created.
		/// </summary>
		public override global::System.Resources.ResourceManager ResourceManager
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return TaskFlowDSLSampleDomainModel.SingletonResourceManager;
			}
		}
	
		/// <summary>
		/// Gets the Singleton ResourceManager for this domain model.
		/// </summary>
		public static global::System.Resources.ResourceManager SingletonResourceManager
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				if (TaskFlowDSLSampleDomainModel.resourceManager == null)
				{
					TaskFlowDSLSampleDomainModel.resourceManager = new global::System.Resources.ResourceManager(ResourceBaseName, typeof(TaskFlowDSLSampleDomainModel).Assembly);
				}
				return TaskFlowDSLSampleDomainModel.resourceManager;
			}
		}
		#endregion
		#region Copy/Remove closures
		/// <summary>
		/// CopyClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter copyClosure;
		/// <summary>
		/// DeleteClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter removeClosure;
		/// <summary>
		/// Returns an IElementVisitorFilter that corresponds to the ClosureType.
		/// </summary>
		/// <param name="type">closure type</param>
		/// <param name="rootElements">collection of root elements</param>
		/// <returns>IElementVisitorFilter or null</returns>
		public override DslModeling::IElementVisitorFilter GetClosureFilter(DslModeling::ClosureType type, global::System.Collections.Generic.ICollection<DslModeling::ModelElement> rootElements)
		{
			switch (type)
			{
				case DslModeling::ClosureType.CopyClosure:
					return TaskFlowDSLSampleDomainModel.CopyClosure;
				case DslModeling::ClosureType.DeleteClosure:
					return TaskFlowDSLSampleDomainModel.DeleteClosure;
			}
			return base.GetClosureFilter(type, rootElements);
		}
		/// <summary>
		/// CopyClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter CopyClosure
		{
			get
			{
				// Incorporate all of the closures from the models we extend
				if (TaskFlowDSLSampleDomainModel.copyClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter copyFilter = new DslModeling::ChainingElementVisitorFilter();
					copyFilter.AddFilter(new TaskFlowDSLSampleCopyClosure());
					copyFilter.AddFilter(new DslModeling::CoreCopyClosure());
					copyFilter.AddFilter(new DslDiagrams::CoreDesignSurfaceCopyClosure());
					
					TaskFlowDSLSampleDomainModel.copyClosure = copyFilter;
				}
				return TaskFlowDSLSampleDomainModel.copyClosure;
			}
		}
		/// <summary>
		/// DeleteClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter DeleteClosure
		{
			get
			{
				// Incorporate all of the closures from the models we extend
				if (TaskFlowDSLSampleDomainModel.removeClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter removeFilter = new DslModeling::ChainingElementVisitorFilter();
					removeFilter.AddFilter(new TaskFlowDSLSampleDeleteClosure());
					removeFilter.AddFilter(new DslModeling::CoreDeleteClosure());
					removeFilter.AddFilter(new DslDiagrams::CoreDesignSurfaceDeleteClosure());
		
					TaskFlowDSLSampleDomainModel.removeClosure = removeFilter;
				}
				return TaskFlowDSLSampleDomainModel.removeClosure;
			}
		}
		#endregion
		#region Diagram rule helpers
		/// <summary>
		/// Enables rules in this domain model related to diagram fixup for the given store.
		/// If diagram data will be loaded into the store, this method should be called first to ensure
		/// that the diagram behaves properly.
		/// </summary>
		public static void EnableDiagramRules(DslModeling::Store store)
		{
			if(store == null) throw new global::System.ArgumentNullException("store");
			
			DslModeling::RuleManager ruleManager = store.RuleManager;
			ruleManager.EnableRule(typeof(global::AppDevUnited.TaskFlowDSLSample.FixUpDiagram));
			ruleManager.EnableRule(typeof(global::AppDevUnited.TaskFlowDSLSample.DecoratorPropertyChanged));
			ruleManager.EnableRule(typeof(global::AppDevUnited.TaskFlowDSLSample.ConnectorRolePlayerChanged));
		}
		
		/// <summary>
		/// Disables rules in this domain model related to diagram fixup for the given store.
		/// </summary>
		public static void DisableDiagramRules(DslModeling::Store store)
		{
			if(store == null) throw new global::System.ArgumentNullException("store");
			
			DslModeling::RuleManager ruleManager = store.RuleManager;
			ruleManager.DisableRule(typeof(global::AppDevUnited.TaskFlowDSLSample.FixUpDiagram));
			ruleManager.DisableRule(typeof(global::AppDevUnited.TaskFlowDSLSample.DecoratorPropertyChanged));
			ruleManager.DisableRule(typeof(global::AppDevUnited.TaskFlowDSLSample.ConnectorRolePlayerChanged));
		}
		#endregion
	}
		
	#region Copy/Remove closure classes
	/// <summary>
	/// Remove closure visitor filter
	/// </summary>
	[global::System.CLSCompliant(true)]
	public partial class TaskFlowDSLSampleDeleteClosure : TaskFlowDSLSampleDeleteClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public TaskFlowDSLSampleDeleteClosure() : base()
		{
		}
	}
	
	/// <summary>
	/// Base class for remove closure visitor filter
	/// </summary>
	[global::System.CLSCompliant(true)]
	public partial class TaskFlowDSLSampleDeleteClosureBase : DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// DomainRoles
		/// </summary>
		private global::System.Collections.Specialized.HybridDictionary domainRoles;
		/// <summary>
		/// Constructor
		/// </summary>
		public TaskFlowDSLSampleDeleteClosureBase()
		{
			#region Initialize DomainData Table
			DomainRoles.Add(global::AppDevUnited.TaskFlowDSLSample.FlowGraphHasComments.CommentDomainRoleId, true);
			DomainRoles.Add(global::AppDevUnited.TaskFlowDSLSample.ActorHasFlowElements.FlowElementDomainRoleId, true);
			#endregion
		}
		/// <summary>
		/// Called to ask the filter if a particular relationship from a source element should be included in the traversal
		/// </summary>
		/// <param name="walker">ElementWalker that is traversing the model</param>
		/// <param name="sourceElement">Model Element playing the source role</param>
		/// <param name="sourceRoleInfo">DomainRoleInfo of the role that the source element is playing in the relationship</param>
		/// <param name="domainRelationshipInfo">DomainRelationshipInfo for the ElementLink in question</param>
		/// <param name="targetRelationship">Relationship in question</param>
		/// <returns>Yes if the relationship should be traversed</returns>
		public virtual DslModeling::VisitorFilterResult ShouldVisitRelationship(DslModeling::ElementWalker walker, DslModeling::ModelElement sourceElement, DslModeling::DomainRoleInfo sourceRoleInfo, DslModeling::DomainRelationshipInfo domainRelationshipInfo, DslModeling::ElementLink targetRelationship)
		{
			return DslModeling::VisitorFilterResult.Yes;
		}
		/// <summary>
		/// Called to ask the filter if a particular role player should be Visited during traversal
		/// </summary>
		/// <param name="walker">ElementWalker that is traversing the model</param>
		/// <param name="sourceElement">Model Element playing the source role</param>
		/// <param name="elementLink">Element Link that forms the relationship to the role player in question</param>
		/// <param name="targetDomainRole">DomainRoleInfo of the target role</param>
		/// <param name="targetRolePlayer">Model Element that plays the target role in the relationship</param>
		/// <returns></returns>
		public virtual DslModeling::VisitorFilterResult ShouldVisitRolePlayer(DslModeling::ElementWalker walker, DslModeling::ModelElement sourceElement, DslModeling::ElementLink elementLink, DslModeling::DomainRoleInfo targetDomainRole, DslModeling::ModelElement targetRolePlayer)
		{
			if (targetDomainRole == null) throw new global::System.ArgumentNullException("targetDomainRole");
			return this.DomainRoles.Contains(targetDomainRole.Id) ? DslModeling::VisitorFilterResult.Yes : DslModeling::VisitorFilterResult.DoNotCare;
		}
		/// <summary>
		/// DomainRoles
		/// </summary>
		private global::System.Collections.Specialized.HybridDictionary DomainRoles
		{
			get
			{
				if (this.domainRoles == null)
				{
					this.domainRoles = new global::System.Collections.Specialized.HybridDictionary();
				}
				return this.domainRoles;
			}
		}
	
	}
	/// <summary>
	/// Copy closure visitor filter
	/// </summary>
	[global::System.CLSCompliant(true)]
	public partial class TaskFlowDSLSampleCopyClosure : TaskFlowDSLSampleCopyClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public TaskFlowDSLSampleCopyClosure() : base()
		{
		}
	}
	/// <summary>
	/// Base class for copy closure visitor filter
	/// </summary>
	[global::System.CLSCompliant(true)]
	public partial class TaskFlowDSLSampleCopyClosureBase : DslModeling::CopyClosureFilter, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public TaskFlowDSLSampleCopyClosureBase():base()
		{
		}
	}
	#endregion
		
}
namespace AppDevUnited.TaskFlowDSLSample
{
	/// <summary>
	/// DomainEnumeration: TaskSort
	/// Description for AppDevUnited.TaskFlowDSLSample.TaskSort
	/// </summary>
	[global::System.CLSCompliant(true)]
	public enum TaskSort
	{
		/// <summary>
		/// Regular
		/// Description for AppDevUnited.TaskFlowDSLSample.TaskSort.Regular
		/// </summary>
		[DslDesign::DescriptionResource("AppDevUnited.TaskFlowDSLSample.TaskSort/Regular.Description", typeof(global::AppDevUnited.TaskFlowDSLSample.TaskFlowDSLSampleDomainModel), "AppDevUnited.TaskFlowDSLSample.GeneratedCode.DomainModelResx")]
		Regular = 0,
		/// <summary>
		/// SuperTask
		/// Description for AppDevUnited.TaskFlowDSLSample.TaskSort.SuperTask
		/// </summary>
		[DslDesign::DescriptionResource("AppDevUnited.TaskFlowDSLSample.TaskSort/SuperTask.Description", typeof(global::AppDevUnited.TaskFlowDSLSample.TaskFlowDSLSampleDomainModel), "AppDevUnited.TaskFlowDSLSample.GeneratedCode.DomainModelResx")]
		SuperTask = 1,
	}
}
