using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetTempBusinessLayer
{
    public class GetAWSData
    {
        public double GetDataFromAWS(DateTime date, double lat, double lon)
        {
            double data=0;
            var s3Client = new AmazonS3Client();
            string bucketName = "noaa-gfs-bdp-pds";// "noaa -gfs-bdp-pds";
            string folderPath = "gfs.20211117/00/atmos/";
            string prefix = "gfs.t00z.pgrb2.0p25.f";  //gfs.20211117/00/atmos/
            try
            {
                using (s3Client)
                {

                    //To find a forecast file, you need to look for the path gfs.YYYYMMDD/00/atmos/gfs.t00z.pgrb2.0p25.f{OFFSET}. Inside the S3 bucket.
                    object req = new Amazon.S3.Model.ListObjectsRequest { BucketName = bucketName, Prefix = (folderPath + prefix) };
                    object resp = s3Client.ListObjectsAsync(bucketName, folderPath + prefix);
                    TransferUtility fileTransferUtility = new TransferUtility(s3Client);
                    foreach (S3Object obj in ((ListObjectsResponse)resp).S3Objects)
                    {
                        string filename = obj.Key.Substring(obj.Key.LastIndexOf(@"/") + 1);
                        string file = GetFileByDate(bucketName, fileTransferUtility, obj, filename,date);
                        data = GetWgrib2Data(file);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught exception when loading a bucket");
                Console.WriteLine(e.Message);
            }
            return data;
            
        }

        private static string GetFileByDate(string bucketName, TransferUtility fileTransferUtility, S3Object obj, string filename, DateTime date)
        {
            //todo: find correct file by date inside bucket
            fileTransferUtility.Download(@"C:\Users\shake\Downloads\" + filename, bucketName, obj.Key);
            return ""; //should be file path
        }

        private double GetWgrib2Data(string file)
        {
            //Wgrib2.exe FILEPATH -match ":(TMP:2 m above ground):" - lon LON LAT
            //todo- get data from Wgrib2 CLI 
            return 68;
        }
    }
}

