﻿using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Docker.DotNet.X509
{
    public class CertificateCredentials : Credentials
    {
        private readonly WinHttpHandler _handler;

        public CertificateCredentials(X509Certificate2 clientCertificate)
        {
            _handler = new WinHttpHandler()
            {
                ClientCertificateOption = ClientCertificateOption.Manual,
            };

            _handler.ClientCertificates.Add(clientCertificate);
        }

        public override HttpMessageHandler Handler
        {
            get
            {
                return _handler;
            }
        }

        public override bool IsTlsCredentials()
        {
            return true;
        }

        public override void Dispose()
        {
            _handler.Dispose();
        }
    }
}