using System;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using System.Collections.Generic;
using Telerik.Sitefinity.Forms.Model;
using Telerik.Sitefinity.Modules.Forms;
using Telerik.Sitefinity.Modules.Forms.Web.UI.Fields;

namespace SitefinityWebApp.wConeChoice.Designer
{
    /// <summary>
    /// Represents a designer for the <typeparamref name="SitefinityWebApp.wConeChoice.wConeChoice"/> widget
    /// </summary>
    public class wConeChoiceDesigner : ControlDesignerBase
    {
        #region Properties
        /// <summary>
        /// Obsolete. Use LayoutTemplatePath instead.
        /// </summary>
        protected override string LayoutTemplateName
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the layout template's relative or virtual path.
        /// </summary>
        public override string LayoutTemplatePath
        {
            get
            {
                if (string.IsNullOrEmpty(base.LayoutTemplatePath))
                    return wConeChoiceDesigner.layoutTemplatePath;
                return base.LayoutTemplatePath;
            }
            set
            {
                base.LayoutTemplatePath = value;
            }
        }

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }
        #endregion

        #region Control references
        /// <summary>
        /// Gets the control that is bound to the Title property
        /// </summary>
        protected virtual Control Title
        {
            get
            {
                return this.Container.GetControl<Control>("Title", true);
            }
        }

        /// <summary>
        /// Gets the control that is bound to the Description property
        /// </summary>
        protected virtual Control Description
        {
            get
            {
                return this.Container.GetControl<Control>("Description", true);
            }
        }

        /// <summary>
        /// Gets the control that is bound to the Example property
        /// </summary>
        protected virtual Control Example
        {
            get
            {
                return this.Container.GetControl<Control>("Example", true);
            }
        }

        /// <summary>
        /// Control that represents the meta field name
        /// </summary>
        public MetaFieldNameTextBox MetaFieldNameTextBox
        {
            get { return this.Container.GetControl<MetaFieldNameTextBox>("metaFieldNameTextBox", true); }
        }
        #endregion

        #region Methods
        protected override void InitializeControls(Telerik.Sitefinity.Web.UI.GenericContainer container)
        {
            // Place your initialization logic here
            this.ConfigureMetaFieldName();
        }

        /// <summary>
        /// Configures the name of the meta field.
        /// </summary>
        private void ConfigureMetaFieldName()
        {
            var control = this.PropertyEditor.Control as IFormFieldControl;
            var formControl = (this.PropertyEditor.ControlData as FormDraftControl);
            var form = formControl.Form;

            // MetaField is not initialized
            if (string.IsNullOrEmpty(control.MetaField.FieldName))
            {
                this.MetaFieldNameTextBox.FieldName = control.GetType().Name + "_" + ((Control)control).ID.ToString();
                this.MetaFieldNameTextBox.ReadOnly = false;
            }
            else
            {
                this.MetaFieldNameTextBox.FieldName = control.MetaField.FieldName;
                if (formControl.Published) // form is already published
                {
                    var fieldName = control.MetaField.FieldName;
                    var fieldExists = form.GetMetaFields().Any(m => m.FieldName == fieldName);
                    if (fieldExists)
                    {
                        this.MetaFieldNameTextBox.ReadOnly = true;
                    }
                }
            }
        }
        #endregion

        #region IScriptControl implementation
        /// <summary>
        /// Gets a collection of script descriptors that represent ECMAScript (JavaScript) client components.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptDescriptor> GetScriptDescriptors()
        {
            var scriptDescriptors = new List<ScriptDescriptor>(base.GetScriptDescriptors());
            var descriptor = (ScriptControlDescriptor)scriptDescriptors.Last();

            descriptor.AddElementProperty("title", this.Title.ClientID);
            descriptor.AddElementProperty("description", this.Description.ClientID);
            descriptor.AddElementProperty("example", this.Example.ClientID);
            descriptor.AddComponentProperty("metaFieldNameTextBox", this.MetaFieldNameTextBox.ClientID);

            return scriptDescriptors;
        }

        /// <summary>
        /// Gets a collection of ScriptReference objects that define script resources that the control requires.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>(base.GetScriptReferences());
            scripts.Add(new ScriptReference(wConeChoiceDesigner.scriptReference));
            return scripts;
        }
        #endregion

        #region Private members & constants
        public static readonly string layoutTemplatePath = "~/wConeChoice/Designer/wConeChoiceDesigner.ascx";
        public const string scriptReference = "~/wConeChoice/Designer/wConeChoiceDesigner.js";
        #endregion
    }
}
 
