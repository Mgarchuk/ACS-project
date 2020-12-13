using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarMarket.Models
{
    public class CommentHub : Hub
    {
        private IServiceProvider sp;
        public CommentHub(IServiceProvider sp)
        {
            this.sp = sp;
        }

     
    }
}
