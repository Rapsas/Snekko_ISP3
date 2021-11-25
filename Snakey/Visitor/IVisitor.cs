using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snakey.Models;
using Snakey.Snacks;

namespace Snakey.Visitor
{
    public interface IVisitor
    {
        public void VisitApple(Snack snack);
        public void VisitLemon(Snack snack);
    }
}
