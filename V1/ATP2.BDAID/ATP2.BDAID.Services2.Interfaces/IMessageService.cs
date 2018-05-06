﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2.BDAID.Entities;

namespace ATP2.BDAID.Services2.Interfaces
{
    public interface IMessageService:IBaseService<Message>
    {
        List<Message> GetAllBySenderReceiver(string SenderEmail,string ReceiverEmail);
    }
}
