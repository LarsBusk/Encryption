using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptDecrypt
{
  public class Mm2ImageDetails : IDataDetails
  {
    public double EncoderPosition;
    public int DroppedLines;
    public int FlashCount;
    public int ReplacedPixels;
    public int NominalSpeed;
    public double MeanSpeed;
    public double StdDevSpeed;
    public double CameraTemperature;
    public double XrayVoltage;
    public double XrayVoltageSet;
    public double XrayCurrent;
    public double XrayCurrentSet;
    public double XrayTemperature;
    public string CameraSerialNumber;
    public int NumberOfImagePixels;
    public int NumberOfNominalDarkPixels;
    public int NumberOfNominalAirPixels;

    public string FileName
    {
      get => Path.GetFileName(this.fileName);

      set => this.fileName = value;
    }

    private string fileName;

    public Mm2ImageDetails(string fileName, double encoderPosition, int droppedLines, int flashCount, int replacedPixels, int nominalSpeed, double meanSpeed,
      double stdDevSpeed, double cameraTemperature, double xrayVoltage, double xrayVoltageSet, double xrayCurrent, double xrayCurrentSet,
      double xrayTemperature, string cameraSerialNumber, int numberOfImagePixels, int numberOfNominalDarkPixels, int numberOfNominalAirPixels)
    {
      this.FileName = fileName;
      this.EncoderPosition = encoderPosition;
      this.DroppedLines = droppedLines;
      this.FlashCount = flashCount;
      this.ReplacedPixels = replacedPixels;
      this.NominalSpeed = nominalSpeed;
      this.MeanSpeed = meanSpeed;
      this.StdDevSpeed = stdDevSpeed;
      this.CameraTemperature = cameraTemperature;
      this.XrayVoltage = xrayVoltage;
      this.XrayVoltageSet = xrayVoltageSet;
      this.XrayCurrent = xrayCurrent;
      this.XrayCurrentSet = xrayCurrentSet;
      this.XrayTemperature = xrayTemperature;
      this.CameraSerialNumber = cameraSerialNumber;
      this.NumberOfImagePixels = numberOfImagePixels;
      this.NumberOfNominalDarkPixels = numberOfNominalDarkPixels;
      this.NumberOfNominalAirPixels = numberOfNominalAirPixels;
    }

    public override string ToString()
    {
      return
        $"{FileName};{EncoderPosition};{DroppedLines};{FlashCount};{ReplacedPixels};{NominalSpeed};{MeanSpeed};{StdDevSpeed};{CameraTemperature};{XrayVoltage};{XrayVoltageSet}" +
        $";{XrayCurrent};{XrayCurrentSet};{XrayTemperature};{CameraSerialNumber};{NumberOfImagePixels};{NumberOfNominalDarkPixels};{NumberOfNominalAirPixels}";
    }

    public string Header()
    {
      return $"Filename;EncoderPosition;DroppedLines;FlashCount;ReplacedPixels;NominalSpeed;MeanSpeed;StdDevSpeed;CameraTemperature;XrayVoltage;XrayVoltageSet" +
             $";XrayCurrent;XrayCurrentSet;XrayTemperature;CameraSerialNumber;NumberOfImagePixels;NumberOfNominalDarkPixels;NumberOfNominalAirPixels";
    }
  }
}
