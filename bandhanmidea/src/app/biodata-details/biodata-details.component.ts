import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BiodataService } from '../_services/biodata.service';

@Component({
  selector: 'app-biodata-details',
  templateUrl: './biodata-details.component.html',
  styleUrls: ['./biodata-details.component.css']
})
export class BiodataDetailsComponent implements OnInit {

  biodataNo!: string;
  biodata: any;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private biodataService: BiodataService
  ) {}

  ngOnInit(): void {
    this.biodataNo = this.route.snapshot.paramMap.get('biodataNo')!;
    this.loadDetails();
  }

  loadDetails() {
    this.biodataService.getBiodataDetails(this.biodataNo)
      .subscribe(res => this.biodata = res);
  }
   goBack() {
    this.router.navigate(['/profile']);
  }
}
