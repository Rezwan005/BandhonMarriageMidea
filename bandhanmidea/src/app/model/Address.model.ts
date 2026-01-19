export interface Address {
  userId: number;

  // Permanent Address
  permanentCountry: string;
  permanentDivisionId: number | null;
  permanentDivision?: string;
  permanentDistrictId: number | null;
  permanentDistrict?: string;
  permanentUpazilaId: number | null;
  permanentUpazila?: string;
  permanentVillage: string;
  permanentRoad: string;
  permanentHouse: string;

  // Current Address
  currentCountry: string;
  currentDivisionId: number | null;
  currentDivision?: string;
  currentDistrictId: number | null;
  currentDistrict?: string;
  currentUpazilaId: number | null;
  currentUpazila?: string;
  currentVillage: string;
  currentRoad: string;
  currentHouse: string;

  // Other
  hometown: string;
  isSameAddress: boolean;
}
