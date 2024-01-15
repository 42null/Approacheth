using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class UIHelpers
    {
        public static float calculateSqueezedHeight(List<GameObject> contentItems, float paddingTop, float paddingBottom)
        {
            float heightOfTotalContent;
            float minY, maxY;

            if (contentItems.Count > 0)
            {
                Vector3[] localCornersFirst = new Vector3[4];
                contentItems[0].GetComponent<RectTransform>().GetLocalCorners(localCornersFirst);
                minY = localCornersFirst[0].y;
                maxY = localCornersFirst[1].y;
                
                // foreach(var contentItem in contentItems)
                for(int i = 1; i < contentItems.Count; i++)
                {
                    GameObject contentItem = contentItems[i];
                    Vector3[] localCorners = new Vector3[4];
                    contentItem.GetComponent<RectTransform>().GetLocalCorners(localCorners);
                    // localCorners[0] = Bottom left
                    // localCorners[1] = Top left
                    // localCorners[2] = Top right
                    // localCorners[3] = Bottom right
                    minY = math.min(minY, localCorners[3].y);
                    maxY = math.min(maxY, localCorners[1].y);
                
                    // heightOfTotalContent += contentItem.GetComponent<RectTransform>().rect.height;
                }

                // heightOfTotalContent = math.abs(minY - maxY);
                heightOfTotalContent = contentItems[0].GetComponent<RectTransform>().rect.height;
                return heightOfTotalContent+paddingTop+paddingBottom;
            }
            else
            {
                return 0;
            }
        }
    }
}