﻿using CosmosApi;
using CosmosApi.Models;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Newtonsoft.Json.Linq;
using System.Text;

namespace LavaIntroExercise.ClientDirectAccessLayer.ClientRequests
{
    public class GetLatestBlockCreator : RequestCreatorBase<BlockQuery, GetLatestBlockRequest>
    {
        // Create a specific instance of the generic RequestCreatorBase, using the Osmosis gRPC API GetLatestBlockAsync endpoint with the parameters defined in our proxy server API.
        // If needed, we can play around with the parameters, endpoint, etc. in complete separation from the server.
        public override async Task<ClientResult<BlockQuery>> CreateAndExecuteRequest(GetLatestBlockRequest parameters)
        {
            try
            {
                using var client = CreateClient(base._baseUrl);
                return ClientResult.Ok(await client.TendermintRpc.GetLatestBlockAsync());
            }
            catch(Exception ex)
            {
                return ClientResult.Fail<BlockQuery>(ex.Message);
            }
        }
    }
}
