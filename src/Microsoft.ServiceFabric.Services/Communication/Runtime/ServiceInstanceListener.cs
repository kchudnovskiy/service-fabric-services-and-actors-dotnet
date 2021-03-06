﻿// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------
namespace Microsoft.ServiceFabric.Services.Communication.Runtime
{
    using System;
    using System.Fabric;

    /// <summary>
    /// Represents the communication listener and its properties for a Stateless Service instance.
    /// Endpoints given out by the communication listener are associated with the name of the communication listener.
    /// </summary>
    public sealed class ServiceInstanceListener
    {
        /// <summary>
        /// <para>The default name of the Service instance listener.</para>
        /// </summary>
        /// <value>
        /// <para>The default name of the Service instance listener.</para>
        /// </value>
        public const string DefaultName = "";

        /// <summary>
        /// <para>Gets the name of the communication listener.</para>
        /// </summary>
        /// <value>
        /// <para>The name of the communication listener.</para>
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        /// <para>Gets the factory method for creating the communication listener.</para>
        /// </summary>
        /// <value>
        /// <para>The factory method for creating the communication listener.</para>
        /// </value>
        /// <remarks>
        /// <para>The factory method takes in a <see cref="System.Fabric.StatelessServiceContext"/> and returns communication listener implementing <see cref="Microsoft.ServiceFabric.Services.Communication.Runtime.ICommunicationListener"/>.</para>
        /// </remarks>
        public Func<StatelessServiceContext, ICommunicationListener> CreateCommunicationListener { get; private set; }

        /// <summary>
        /// Initializes a new instance of ServiceInstanceListener.
        /// </summary>
        /// <param name="createCommunicationListener">Factory method for creating the communication listener.</param>
        /// <param name="name">Name of the communication listener. This parameter is optional if the Stateless Service has only one communication listener. If it is not given, the Name is set to DefaultName.</param>
        public ServiceInstanceListener(
            Func<StatelessServiceContext, ICommunicationListener> createCommunicationListener,
            string name = DefaultName)
        {
            this.CreateCommunicationListener = createCommunicationListener;
            this.Name = name;
        }
    }
}
