Type.registerNamespace("SitefinityWebApp.wConeChoice.Designer");

SitefinityWebApp.wConeChoice.Designer.wConeChoiceDesigner = function (element) {
    /* Initialize Title fields */
    this._title = null;
    
    /* Initialize Description fields */
    this._description = null;
    
    /* Initialize Example fields */
    this._example = null;
    
    /* Initialize the meta field name TextBox used in form widget designers */
    this._metaFieldNameTextBox = null;

    /* Calls the base constructor */
    SitefinityWebApp.wConeChoice.Designer.wConeChoiceDesigner.initializeBase(this, [element]);
}

SitefinityWebApp.wConeChoice.Designer.wConeChoiceDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        SitefinityWebApp.wConeChoice.Designer.wConeChoiceDesigner.callBaseMethod(this, 'initialize');
    },
    dispose: function () {
        /* this is the place to unbind/dispose the event handlers created in the initialize method */
        SitefinityWebApp.wConeChoice.Designer.wConeChoiceDesigner.callBaseMethod(this, 'dispose');
    },

    /* --------------------------------- public methods ---------------------------------- */

    findElement: function (id) {
        var result = jQuery(this.get_element()).find("#" + id).get(0);
        return result;
    },

    /* Called when the designer window gets opened and here is place to "bind" your designer to the control properties */
    refreshUI: function () {
        var controlData = this._propertyEditor.get_control(); /* JavaScript clone of your control - all the control properties will be properties of the controlData too */

        /* RefreshUI Title */
        jQuery(this.get_title()).val(controlData.Title);

        /* RefreshUI Description */
        jQuery(this.get_description()).val(controlData.Description);

        /* RefreshUI Example */
        jQuery(this.get_example()).val(controlData.Example);
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        /* ApplyChanges Title */
        controlData.Title = jQuery(this.get_title()).val();

        /* ApplyChanges Description */
        controlData.Description = jQuery(this.get_description()).val();

        /* ApplyChanges Example */
        controlData.Example = jQuery(this.get_example()).val();
        controlData.MetaField.FieldName = this.get_metaFieldNameTextBox().get_value();
    },

    /* --------------------------------- event handlers ---------------------------------- */

    /* --------------------------------- private methods --------------------------------- */

    /* --------------------------------- properties -------------------------------------- */

    /* Title properties */
    get_title: function () { return this._title; }, 
    set_title: function (value) { this._title = value; },

    /* Description properties */
    get_description: function () { return this._description; }, 
    set_description: function (value) { this._description = value; },

    /* Example properties */
    get_example: function () { return this._example; }, 
    set_example: function (value) { this._example = value; },

    /* metaFieldNameTextBox properties */
    get_metaFieldNameTextBox: function () { return this._metaFieldNameTextBox; },
    set_metaFieldNameTextBox: function (value) { this._metaFieldNameTextBox = value; }
}

SitefinityWebApp.wConeChoice.Designer.wConeChoiceDesigner.registerClass('SitefinityWebApp.wConeChoice.Designer.wConeChoiceDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
