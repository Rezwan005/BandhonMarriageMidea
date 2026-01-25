import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Biodata } from '../model/biodata.model';
import { Address } from '../model/Address.model';
import { DataLookup } from '../model/lookup.model';
import { Education } from '../model/Education.model';
import { PersonalInfo } from '../model/personalinfo.model';
import { BiodataProfile } from '../model/biodataprofile.model';
import { environment } from 'src/environments/environment.prod';


@Injectable({
  providedIn: 'root'
})
export class BiodataService {


  apiUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}

  saveBiodata(data: Biodata): Observable<any> {
    return this.http.post(this.apiUrl+'/general-info', data);
  }
   getBiodataByUserId(userId: number): Observable<Biodata> {
    return this.http.get<Biodata>(`${this.apiUrl+'/general-info'}/${userId}`);
  }
    // SAVE / UPDATE
  saveAddress(data: Address): Observable<any> {
    return this.http.post(`${this.apiUrl}/save`, data);
  }

  // GET BY USER ID
  getAddressByUserId(userId: number): Observable<Address> {
    return this.http.get<Address>(`${this.apiUrl+'/address'}/${userId}`);
  }
 getLookup(category: string) {
  return this.http.get<DataLookup[]>(
    `${this.apiUrl}/lookupcategory/${category}`
  );
}
  // 🔹 Save or Update education
  saveEducation(data: Education): Observable<any> {
    return this.http.post(this.apiUrl + '/saveEducation', data);
  }

  // 🔹 Get education by user id
  getEducationByUserId(userId: number): Observable<Education> {
    return this.http.get<Education>(
      `${this.apiUrl + '/get-by-user'}/${userId}`
    );
  }
    saveOrUpdatePersonalInfo(data: FormData) {
    return this.http.post(this.apiUrl + '/savePersonalInfo', data);
  }

  getPersonalInfoByUserId(userId: number): Observable<PersonalInfo> {
    return this.http.get<PersonalInfo>(
      `${this.apiUrl + '/get-personalinfo-by-user'}/${userId}`
    );
  }
saveOrUpdateOccupation(data: any): Observable<any> {
  debugger;
    return this.http.post(
      `${this.apiUrl}/saveOccupation`,
      data
    );
  }
saveOrUpdateContact(data: any): Observable<any> {
  debugger;
    return this.http.post(
      `${this.apiUrl}/saveContactInfo`,
      data
    );
  }
  getOccupationByUserId(userId: number): Observable<any> {
    return this.http.get(
      `${this.apiUrl}/get-occupation-by-user/${userId}`
    );
  }
   getContactByUserId(userId: number): Observable<any> {
    return this.http.get(
      `${this.apiUrl}/get-contact-by-user/${userId}`
    );
  }

   getProfilesByUserId(filters: any): Observable<{ success: boolean, data: BiodataProfile[] }> {
      // return this.http.get<{ success: boolean, data: BiodataProfile[] }>(
      //   `${this.apiUrl}/profiles/${userId}`
      // );
      return this.http.post<{ success: boolean, data: BiodataProfile[] }>(`${this.apiUrl}/profiles/search`, filters);

     }
    getSteps(): Observable<any> {
    return this.http.get(
      `${this.apiUrl}/steps`
    );
  }
    StartBiodata(): Observable<any> {
      debugger;
    return this.http.post<any>(
      `${this.apiUrl}/start`,
      {}   // empty body is required
    );
  }
  getBiodataDetails(biodataNo: string) {
  return this.http.get<any>(
    `${this.apiUrl}/details/${biodataNo}`
  );
}
}
