using System.ComponentModel.DataAnnotations;
using FluentValidation;
using MediatR;
using Newtonsoft.Json;

namespace PanteraTech.EaiApp.Domain.User.Login
{
  public class Command<T,R> : AbstractValidator<T>, IRequest<R>
  {

    [JsonProperty]
    public ValidationResult ValidationResult {get; set;}
    
    public virtual bool IsValid(){
      return true;
    }
  }
}