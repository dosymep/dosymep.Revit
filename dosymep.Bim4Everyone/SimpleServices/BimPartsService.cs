using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace dosymep.Bim4Everyone.SimpleServices {
    internal class BimModelPartsService : IBimModelPartsService {
        public BimModelPart GetBimModelPart(string documentName) {
            if(string.IsNullOrEmpty(documentName)) {
                throw new ArgumentException("Value cannot be null or empty.", nameof(documentName));
            }

            return GetBimModelParts()
                .OrderBy(item => item.GetType() == typeof(BimModelSubPart))
                .FirstOrDefault(item => item.IsBimPart(documentName));
        }

        public bool InAnyBimModelParts(string documentName, BimModelPart bimModelPart) {
            return GetBimModelPart(documentName) == bimModelPart;
        }

        public bool InAnyBimModelParts(string documentName, params BimModelPart[] bimModelParts) {
            return InAnyBimModelParts(documentName, bimModelParts.AsEnumerable());
        }

        public bool InAnyBimModelParts(string documentName, IEnumerable<BimModelPart> bimModelParts) {
            return bimModelParts.Any(item => GetBimModelPart(documentName) == item);
        }

        public IEnumerable<BimModelPart> GetBimModelParts() {
            return typeof(BimModelPart)
                .GetFields(BindingFlags.Static)
                .Select(item => item.GetValue(null))
                .OfType<BimModelPart>();
        }

        public IEnumerable<BimModelPart> GetBimModelSubParts(BimModelPart parentPart) {
            if(parentPart == null) {
                throw new ArgumentNullException(nameof(parentPart));
            }

            return GetBimModelParts()
                .OfType<BimModelSubPart>()
                .Where(item => item.Parent == parentPart);
        }
    }
}