﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using x2;

namespace Server.Instance
{
    public class InstanceServer : AsyncTcpServer
    {
        Config config;

        public InstanceServer(Config cfg)
            : base(cfg.Name)
        {
            config = cfg;
        }

        protected override void Setup()
        {
            base.Setup();

            InitializeFactoryEvents();
            InitializeBinds();

            Listen(config.Port);
        }

        void InitializeFactoryEvents()
        {
            EventFactory.Register(Assembly.Load(config.EventAssembly));
        }

        void InitializeBinds()
        {
            new Event().Bind(Send);
        }
    }
}
