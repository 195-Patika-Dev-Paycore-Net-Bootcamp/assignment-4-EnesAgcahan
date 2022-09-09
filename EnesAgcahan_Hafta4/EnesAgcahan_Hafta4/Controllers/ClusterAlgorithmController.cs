using EnesAgcahan_Hafta4;
using EnesAgcahan_Hafta4.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnesAgcahan_Hafta4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClusterAlgorithmController : ControllerBase
    {
        private readonly IMapperSession session;
        public ClusterAlgorithmController(IMapperSession session)
        {
            this.session = session;
        }
        [HttpGet]

        public ActionResult<List<List<container>>> GetContainerCluster(int clusterCount, int maxIterations)
        {

            List<container> result = session.Containers.ToList();

            var partitions = KMeans.Cluster(result.ToArray(), clusterCount, maxIterations);

             
            return Ok(partitions);
        }

    }
}
