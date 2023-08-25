using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IAdditionalDataProcessor
{
    void ProcessAdditionalData(Dictionary<string, string> additionalData);
}
