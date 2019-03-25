using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace jsonTest
{

    public class BimsPlane
    {
        /// <summary>
        /// 空间区域必须是闭合的，各线段相连
        /// </summary>
        public List<BimsLine> region { get; set; }
    }

    public class BimsLine
    {
        /// <summary>
        /// 线类型
        /// </summary>
        public string curveType { get; set; }
        /// <summary>
        /// 起始点
        /// </summary>
        public BimsPoint startPoint { get; set; }
        /// <summary>
        /// 结束点
        /// </summary>
        public BimsPoint endPoint { get; set; }
    }

    public class bimsEllipse
    {
        //中心点
        public BimsPoint center { get; set; }

        //长轴
        public BimsPoint vector0 { get; set; }

        //短轴
        public BimsPoint vector90{ get; set; }

        //起始角度
        public double startAngle { get; set; }

        //扫掠角度
        public double sweepAngle { get; set; }
    }

    public class BimsPoint
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public bool IsEqual(BimsPoint point, double diff = 20)
        {
            return Equal(point.x, x, diff) && Equal(point.y, y, diff) && Equal(point.z, z, diff);
        }

        bool Equal(double d1, double d2, double diff)
        {
            return Math.Abs(d1 - d2) < diff;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<BimsPlane> spaceRegions = new List<BimsPlane>();
            string interfacepoints = "[[{\"curveType\":\"XDBBoundLine\",\"startPoint\":{\"x\":6661.6789466940454,\"y\":5.2076476930417636E-11,\"z\":71699.999999999985},\"endPoint\":{\"x\":9429.9999999999982,\"y\":4.3130734321534553E-11,\"z\":71699.999999999985}},{\"curveType\":\"XDBBoundLine\",\"startPoint\":{\"x\":9429.9999999999982,\"y\":4.3043968389611107E-11,\"z\":71699.999999999985},\"endPoint\":{\"x\":9430.0,\"y\":1279.9999999999518,\"z\":71699.999999999985}},{\"curveType\":\"XDBBoundLine\",\"startPoint\":{\"x\":9430.0,\"y\":1279.9999999999518,\"z\":71699.999999999985},\"endPoint\":{\"x\":9430.0000000000018,\"y\":2019.9999999999482,\"z\":71699.999999999985}},{\"curveType\":\"XDBBoundLine\",\"startPoint\":{\"x\":9430.0000000000018,\"y\":2019.9999999999482,\"z\":71699.999999999985},\"endPoint\":{\"x\":9430.0000000000036,\"y\":3569.9999999494976,\"z\":71699.999999999985}},{\"curveType\":\"XDBBoundLine\",\"startPoint\":{\"x\":9430.0000000000036,\"y\":3569.9999999494976,\"z\":71699.999999999985},\"endPoint\":{\"x\":8499.99999999997,\"y\":3569.9999999494976,\"z\":71699.999999999985}},{\"curveType\":\"XDBBoundLine\",\"startPoint\":{\"x\":8499.99999999997,\"y\":3569.9999999494976,\"z\":71699.999999999985},\"endPoint\":{\"x\":7119.9999999999709,\"y\":3569.9999999494976,\"z\":71699.999999999985}},{\"curveType\":\"XDBBoundLine\",\"startPoint\":{\"x\":7119.9999999999709,\"y\":3569.9999999494976,\"z\":71699.999999999985},\"endPoint\":{\"x\":5819.9999999999982,\"y\":3569.9999999494976,\"z\":71699.999999999985}},{\"curveType\":\"XDBBoundLine\",\"startPoint\":{\"x\":5819.9999999999982,\"y\":3569.9999999494976,\"z\":71699.999999999985},\"endPoint\":{\"x\":5819.9999999999982,\"y\":330.79480729363786,\"z\":71699.999999999985}},{\"curveType\":\"XDBEllipse\",\"center\":{\"x\":9837.5080723557767,\"y\":9316.8114261001065,\"z\":71699.999999999985},\"vector0\":{\"x\":9843.2141998896823,\"y\":0.0,\"z\":0.0},\"vector90\":{\"x\":0.0,\"y\":9843.2141998896823,\"z\":0.0},\"startAngle\":4.2919622924309033,\"sweepAngle\":0.09190780640197449}]]";
            JArray spaceReginArray = (JArray)JsonConvert.DeserializeObject(interfacepoints);
            foreach (var item in spaceReginArray)
            {
                foreach (var child in item.Children())
                {
                    string cureType = child.Value<string>("curveType");
                    if ("XDBBoundLine".Equals(cureType))
                    {
                        var line = (BimsLine)JsonConvert.DeserializeObject<BimsLine>(child.ToString());
                    }
                    else if ("XDBEllipse".Equals(cureType) )
                    {
                        var Ellipse = (bimsEllipse)JsonConvert.DeserializeObject<bimsEllipse>(child.ToString());
                    }
                }
                //var chirlditem = item.First;
                BimsPlane space = new BimsPlane();
                space.region = (List<BimsLine>)JsonConvert.DeserializeObject<List<BimsLine>>(item.ToString());
                spaceRegions.Add(space);
            }
            
        }
    }
}
