﻿using System;
using System.Runtime.InteropServices;
using static Hyperledger.Indy.Utils.CallbackHelper;

namespace Hyperledger.Indy.PoolApi
{
    internal static class NativeMethods
    {
        /// <summary>
        /// Creates a new local pool ledger configuration that can be used later to connect pool nodes.
        /// </summary>
        /// <param name="command_handle">The handle for the command that will be passed to the callback.</param>
        /// <param name="config_name">Name of the pool ledger configuration.</param>
        /// <param name="config">Pool configuration json. if NULL, then default config will be used.</param>
        /// <param name="cb">The function that will be called when the asynchronous call is complete.</param>
        /// <returns>0 if the command was initiated successfully.  Any non-zero result indicates an error.</returns>
        [DllImport(Consts.NATIVE_LIB_NAME, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        internal static extern int indy_create_pool_ledger_config(int command_handle, string config_name, string config, IndyMethodCompletedDelegate cb);

        /// <summary>
        /// Deletes created pool ledger configuration.
        /// </summary>
        /// <param name="command_handle">The handle for the command that will be passed to the callback.</param>
        /// <param name="config_name">Name of the pool ledger configuration to delete.</param>
        /// <param name="cb">The function that will be called when the asynchronous call is complete.</param>
        /// <returns>0 if the command was initiated successfully.  Any non-zero result indicates an error.</returns>
        [DllImport(Consts.NATIVE_LIB_NAME, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        internal static extern int indy_delete_pool_ledger_config(int command_handle, string config_name, IndyMethodCompletedDelegate cb);

        /// <summary>
        /// Opens pool ledger and performs connecting to pool nodes.
        /// </summary>
        /// <param name="command_handle">The handle for the command that will be passed to the callback.</param>
        /// <param name="config_name">Name of the pool ledger configuration.</param>
        /// <param name="config">Runtime pool configuration json. If null the default configuration will be used.</param>
        /// <param name="cb">The function that will be called when the asynchronous call is complete.</param>
        /// <returns>0 if the command was initiated successfully.  Any non-zero result indicates an error.</returns>
        [DllImport(Consts.NATIVE_LIB_NAME, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        internal static extern int indy_open_pool_ledger(int command_handle, string config_name, string config, OpenPoolLedgerCompletedDelegate cb);

        /// <summary>
        /// Delegate to be uses on completion of calls to indy_open_pool_ledger.
        /// </summary>
        /// <param name="xcommand_handle">The handle for the command that initiated the callback.</param>
        /// <param name="err">The outcome of execution of the command.</param>
        /// <param name="pool_handle">The handle for the opened pool.</param>
        internal delegate void OpenPoolLedgerCompletedDelegate(int xcommand_handle, int err, IntPtr pool_handle);

        /// <summary>
        /// Refreshes a local copy of a pool ledger and updates pool nodes connections.
        /// </summary>
        /// <param name="command_handle">The handle for the command that will be passed to the callback.</param>
        /// <param name="handle">Pool handle returned by indy_open_pool_ledger</param>
        /// <param name="cb">The function that will be called when the asynchronous call is complete.</param>
        /// <returns>0 if the command was initiated successfully.  Any non-zero result indicates an error.</returns>
        [DllImport(Consts.NATIVE_LIB_NAME, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        internal static extern int indy_refresh_pool_ledger(int command_handle, IntPtr handle, IndyMethodCompletedDelegate cb);

        /// <summary>
        /// Closes opened pool ledger, opened nodes connections and frees allocated resources.
        /// </summary>
        /// <param name="command_handle">The handle for the command that will be passed to the callback.</param>
        /// <param name="handle">pool handle returned by indy_open_pool_ledger.</param>
        /// <param name="cb">The function that will be called when the asynchronous call is complete.</param>
        /// <returns>0 if the command was initiated successfully.  Any non-zero result indicates an error.</returns>
        [DllImport(Consts.NATIVE_LIB_NAME, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        internal static extern int indy_close_pool_ledger(int command_handle, IntPtr handle, IndyMethodCompletedDelegate cb);
    }
}
