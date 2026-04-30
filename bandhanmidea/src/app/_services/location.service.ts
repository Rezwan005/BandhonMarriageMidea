import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment.prod";

@Injectable({ providedIn: 'root' })
export class LocationService {


  private baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}

  getDivisions() {
    return this.http.get(`${this.baseUrl}/divisions`);
  }

  getDistrictsByDivision(divId: number) {
    return this.http.get(`${this.baseUrl}/districts/${divId}`);
  }

  getUpazilasByDistrict(distId: number) {
    return this.http.get(`${this.baseUrl}/upazilas/${distId}`);
  }

  getUnionsByUpazila(upzId: number) {
    return this.http.get(`${this.baseUrl}/unions/${upzId}`);
  }
}
