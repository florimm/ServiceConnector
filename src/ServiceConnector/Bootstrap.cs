using System;
using System.Collections.Generic;
using System.Text;
using Lamar;
using ServiceConnector.CommonAdapters;
using ServiceConnector.CommonServices;

namespace ServiceConnector
{
    public class Bootstrap
    {
        public Bootstrap(MediatR.IMediator mediator)
        {
            var initService = new InitService();
            var treeNode = new TreeNode<BaseService>(initService);

            var sqlService = new SQLService();
            var node = treeNode.AddChild(sqlService);
        }
    }
}
