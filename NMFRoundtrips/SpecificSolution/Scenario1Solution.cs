using System;
using NMF.Synchronizations;

using V1Person = TTC2020.Roundtrip.Scenario1.V1.Model.Person;
using V2Person = TTC2020.Roundtrip.Scenario1.V2.Model.Person;

namespace TTC2020.Roundtrip
{
    public class Scenario1Solution : ReflectiveSynchronization
    {
        public class Person2Person : SynchronizationRule<V1Person, V2Person>
        {
            public override void DeclareSynchronization()
            {
                Synchronize(p => p.Name, p => p.Name);

                Synchronize(p => p.Age, p => 2020 - p.Ybirth);
            }

            public override bool ShouldCorrespond(V1Person left, V2Person right, ISynchronizationContext context)
            {
                return left.Name == right.Name;
            }
        }
    }
}
