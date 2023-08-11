using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PaxSender.Data;
using PaxSender.Models;
#nullable disable

namespace PaxSender
{

public  class AppStateService
 {
   public bool ValorCompartido { get; set; } = false;
 }
}