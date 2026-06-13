// FormValidationHelper.cs - Provides helper methods for validating form fields and managing validation state in Blazor forms
using Microsoft.AspNetCore.Components.Forms;

public class FormValidationHelper
{
  private readonly EditContext _editContext;
  private readonly object _model;
  private readonly HashSet<string> _validatedFields = new();

  public FormValidationHelper(EditContext editContext, object model)
  {
    _editContext = editContext;
    _model = model;
  }

  public void ValidateField(string fieldName)
  {
    _validatedFields.Add(fieldName);

    _editContext.NotifyFieldChanged(
        new FieldIdentifier(_model, fieldName));
  }

  public string GetFieldCssClass(string fieldName)
  {
    var field = new FieldIdentifier(_model, fieldName);

    bool hasErrors =
        _editContext.GetValidationMessages(field).Any();

    bool hasBeenModified =
        _editContext.IsModified(field);

    if (!hasBeenModified)
      return "form-control";

    return hasErrors
        ? "form-control my-invalid"
        : "form-control my-valid";
  }

  public bool IsFormValid(params string[] requiredFields)
  {
    return requiredFields.All(f => _validatedFields.Contains(f))
        && !_editContext.GetValidationMessages().Any();
  }
}