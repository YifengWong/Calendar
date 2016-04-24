using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar_run.Util {
    class TileXml {
        static public string XmlString = @"
        <tile>
            <visual>
                 <binding template='TileSmall'>
                    <group>
                        <subgroup>
                            <text hint-style='subtitle'>titleWhat</text>
                            <text hint-style= 'subtle' >detailsWhat</text>
                        </subgroup>
                    </group>
                </binding>

                <binding template='TileMedium'>
                    <group>
                        <subgroup>
                            <text hint-style='subtitle' >titleWhat</text>
                            <text hint-style= 'subtle' >detailsWhat</text>
                        </subgroup>
                    </group>
                </binding>

                <binding template='TileLarge'>
                    <group>
                        <subgroup>
                            <text hint-style='subtitle'>titleWhat</text>
                            <text hint-style= 'subtle' >detailsWhat</text>
                            
                        </subgroup>
                    </group>
                </binding>

                <binding template='TileWide'>
                    <group>
                        <subgroup>
                            <text hint-style='subtitle'>titleWhat</text>
                            <text hint-style= 'subtle' >detailsWhat</text>
                        </subgroup>
                    </group>
                </binding>
            </visual>
        </tile>";
    }
}
