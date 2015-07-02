﻿using System;

namespace ServiceStack.Aws.SQS
{
    public class SqsQueueDefinition
    {
        public const int MaxWaitTimeSeconds = 20;
        public const int DefaultWaitTimeSeconds = MaxWaitTimeSeconds;
        public const int MaxVisibilityTimeoutSeconds = 43200;
        public const int DefaultVisibilityTimeoutSeconds = 300;
        
        public const int MaxBatchReceiveItems = 10;
        public const int MaxBatchDeleteItems = 10;
        public const int MaxBatchSendItems = 10;
        public const int MaxBatchCvItems = 10;
        public const int DefaultTempQueueRetentionSeconds = 60 * 60 * 6;
        public const int DefaultPermanentQueueRetentionSeconds = 60 * 60 * 24 * 5;

        private static readonly char[] _validNonAlphaNumericChars = new[] { '-', '_' };

        public SqsQueueDefinition()
        {
            SendBufferSize = MaxBatchSendItems;
            ReceiveBufferSize = MaxBatchReceiveItems;
            DeleteBufferSize = MaxBatchDeleteItems;
            ChangeVisibilityBufferSize = MaxBatchCvItems;
            ReceiveWaitTime = DefaultWaitTimeSeconds;
            VisibilityTimeout = DefaultVisibilityTimeoutSeconds;
        }

        public string QueueName
        {
            get { return SqsQueueName.QueueName; }
        }

        public string AwsQueueName
        {
            get { return SqsQueueName.AwsQueueName; }
        }

        public SqsQueueName SqsQueueName { get; set; }

        public string QueueUrl { get; set; }
        public int VisibilityTimeout { get; set; }
        public int ReceiveWaitTime { get; set; }
        public long CreatedTimestamp { get; set; }
        public SqsRedrivePolicy RedrivePolicy { get; set; }
        public bool DisableBuffering { get; set; }
        
        private int _sendBufferSize = 1;
        public int SendBufferSize
        {
            get { return _sendBufferSize; }
            set
            {
                _sendBufferSize = value > 0
                                      ? value
                                      : 1;
            }
        }

        private int _receiveBufferSize = 1;
        public int ReceiveBufferSize
        {
            get { return _receiveBufferSize; }
            set
            {
                _receiveBufferSize = value > 0
                                         ? value
                                         : 1;
            }
        }

        private int _deleteBufferSize = 1;
        public int DeleteBufferSize
        {
            get { return _deleteBufferSize; }
            set
            {
                _deleteBufferSize = value > 0
                                        ? value
                                        : 1;
            }
        }

        private int _cvBufferSize = 1;
        public int ChangeVisibilityBufferSize
        {
            get { return _cvBufferSize; }
            set
            {
                _cvBufferSize = value > 0
                                        ? value
                                        : 1;
            }
        }

        public long ApproximateNumberOfMessages { get; set; }
        public string QueueArn { get; set; }

        public static char[] ValidNonAlphaNumericChars
        {
            get { return _validNonAlphaNumericChars; }
        }
        
        public static int GetValidQueueWaitTime(int value)
        {
            return value >= 0 && value <= MaxWaitTimeSeconds
                       ? value
                       : value < 0
                             ? 0
                             : 20;
        }

        public static int GetValidVisibilityTimeout(int value)
        {
            return value >= 0 && value <= MaxVisibilityTimeoutSeconds
                       ? value
                       : value < 0
                             ? 0
                             : 43200;
        }
    }
}
