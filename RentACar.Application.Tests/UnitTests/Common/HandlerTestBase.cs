using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Tests.UnitTests.Common
{
    public abstract class HandlerTestBase
    {
        protected readonly Mock<IMapper> MockMapper;
        protected readonly CancellationToken CancellationToken;

        protected HandlerTestBase()
        {
            MockMapper = new Mock<IMapper>();
            CancellationToken = System.Threading.CancellationToken.None;
        }
    }
}
