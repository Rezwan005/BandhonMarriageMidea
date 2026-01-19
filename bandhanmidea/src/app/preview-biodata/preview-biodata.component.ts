import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-preview-biodata',
  templateUrl: './preview-biodata.component.html',
  styleUrls: ['./preview-biodata.component.css']
})
export class PreviewBiodataComponent {
  @Input() biodata: any;
  userBiodata = {
    photoUrl: 'assets/profile.jpg',
    type: "Male's Biodata",
    maritalStatus: "Never Married",
    birthYear: "January, 1996",
    height: "4'11\"",
    complexion: "Brown",
    weight: "60 kg",
    bloodGroup: "AB-",
    nationality: "Bangladeshi",
    permanentAddress: "Bandarban Sadar, Bandarban...",
    presentAddress: "Bandarban Sadar, Bandarban...",
    grewUp: "sdfsdf",
    educationMethod: "General",
    highestQualification: "SSC",
    sscYear: 2022,
    group: "Commerce",
    result: "B",
    hscYear: "HSC first year",
    otherQualifications: "fdg",
    islamicTitles: "Maolana, Mufti"
  };
  copyBiodataLink() {
    const link = window.location.href; // or your generated link
    navigator.clipboard.writeText(link).then(() => {
      alert('Biodata link copied!');
    });
  }
}
