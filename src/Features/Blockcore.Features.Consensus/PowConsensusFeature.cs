﻿using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Blockcore.Base;
using Blockcore.Base.Deployments;
using Blockcore.Connection;
using Blockcore.Consensus;
using Blockcore.Consensus.Chain;
using Blockcore.Interfaces;
using Blockcore.Networks;
using Blockcore.Signals;
using Microsoft.Extensions.Logging;
using NBitcoin;

[assembly: InternalsVisibleTo("Blockcore.Features.Miner.Tests")]
[assembly: InternalsVisibleTo("Blockcore.Features.Consensus.Tests")]

namespace Blockcore.Features.Consensus
{
    public class PowConsensusFeature : ConsensusFeature
    {
        private readonly IChainState chainState;
        private readonly IConnectionManager connectionManager;
        private readonly IConsensusManager consensusManager;
        private readonly NodeDeployments nodeDeployments;
        private readonly ChainIndexer chainIndexer;
        private readonly IInitialBlockDownloadState initialBlockDownloadState;
        private readonly IPeerBanning peerBanning;
        private readonly ILoggerFactory loggerFactory;

        public PowConsensusFeature(
            Network network,
            IChainState chainState,
            IConnectionManager connectionManager,
            IConsensusManager consensusManager,
            NodeDeployments nodeDeployments,
            ChainIndexer chainIndexer,
            IInitialBlockDownloadState initialBlockDownloadState,
            IPeerBanning peerBanning,
            ISignals signals,
            ILoggerFactory loggerFactory) : base(network, chainState, connectionManager, signals, consensusManager, nodeDeployments)
        {
            this.chainState = chainState;
            this.connectionManager = connectionManager;
            this.consensusManager = consensusManager;
            this.nodeDeployments = nodeDeployments;
            this.chainIndexer = chainIndexer;
            this.initialBlockDownloadState = initialBlockDownloadState;
            this.peerBanning = peerBanning;
            this.loggerFactory = loggerFactory;

            this.chainState.MaxReorgLength = network.Consensus.MaxReorgLength;
        }

        /// <summary>
        /// Prints command-line help. Invoked via reflection.
        /// </summary>
        /// <param name="network">The network to extract values from.</param>
        public static new void PrintHelp(Network network)
        {
            ConsensusFeature.PrintHelp(network);
        }

        /// <summary>
        /// Get the default configuration. Invoked via reflection.
        /// </summary>
        /// <param name="builder">The string builder to add the settings to.</param>
        /// <param name="network">The network to base the defaults off.</param>
        public static new void BuildDefaultConfigurationFile(StringBuilder builder, Network network)
        {
            ConsensusFeature.BuildDefaultConfigurationFile(builder, network);
        }

        /// <inheritdoc />
        public override Task InitializeAsync()
        {
            base.InitializeAsync();

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public override void Dispose()
        {
        }
    }


}