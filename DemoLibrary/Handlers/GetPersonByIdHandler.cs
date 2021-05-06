using DemoLibrary.DataAccess;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoLibrary.Handlers
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonModel>
    {
        private readonly IMediator _mediatR;

        public GetPersonByIdHandler(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        public async Task<PersonModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _mediatR.Send(new GetPersonListQuery());

            var output = result.FirstOrDefault(x => x.Id == request.Id);

            return output;
        }


        /*private readonly IDataAccess _data;

        public GetPersonByIdHandler(IDataAccess data)
        {
            _data = data;
        }

        public Task<PersonModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_data.GetPerson(request.id));
        }*/
    }
}
