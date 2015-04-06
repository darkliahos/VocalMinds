using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using VMUtils.Interfaces;
using VM_Model;

namespace VMUtils
{
    public class SocialScenarioMerge : IMerge<ImportedSocialScenarios>
    {
        public bool CompareSourceWithTarget(ImportedSocialScenarios source, ImportedSocialScenarios target)
        {
            if (source.SocialScenario.Count != target.SocialScenario.Count)
            {
                return true;
            }

            foreach (var socialScenario in source.SocialScenario)
            {
                var newScenarioMatch = target.SocialScenario.First(x => x.Id == socialScenario.Id);

                if (newScenarioMatch.FriendlyName != socialScenario.FriendlyName)
                {
                    return true;
                }

                if (newScenarioMatch.Author != socialScenario.Author)
                {
                    return true;
                }

                if (newScenarioMatch.Imported != socialScenario.Imported)
                {
                    return true;
                }

                if (newScenarioMatch.VideoSegment.Count != socialScenario.VideoSegment.Count)
                {
                    return true;
                }

                //TODO it could be argued that individual video segements may have differences however this may not be very performant!
            }
            return false;
        }

        public ImportedSocialScenarios MergeFiles(ImportedSocialScenarios source, ImportedSocialScenarios target)
        {
            var mergedObject = new ImportedSocialScenarios()
            {
                Creation = source.Creation,
                LastModified = DateTime.Now,
                IsCurrentlyLocked = true,
                LastWrittenProcessId = Process.GetCurrentProcess().Id,
                SocialScenario = new List<SocialScenario>()
            };

            foreach (var scenario in target.SocialScenario)
            {
                if (!source.SocialScenario.Exists(x => x.Id == scenario.Id))
                {
                    mergedObject.SocialScenario.Add(scenario);
                }
                else
                {
                    var sourceObject = source.SocialScenario.First(x => x.Id == scenario.Id);
                    mergedObject.SocialScenario.Add(scenario.Imported > sourceObject.Imported
                        ? scenario
                        : sourceObject);
                }
            }

            foreach (var sourceScenario in source.SocialScenario.Where(sourceScenario => !mergedObject.SocialScenario.Exists(x => x.Id == sourceScenario.Id)))
            {
                mergedObject.SocialScenario.Add(sourceScenario);
            }

            return mergedObject;
        }
    }
}
