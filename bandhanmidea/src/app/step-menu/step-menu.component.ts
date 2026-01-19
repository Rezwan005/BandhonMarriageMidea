import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BiodataService } from '../_services/biodata.service';
import { AuthService } from '../_services/authService.service';

@Component({
  selector: 'app-step-menu',
  templateUrl: './step-menu.component.html',
  styleUrls: ['./step-menu.component.css']
})
export class StepMenuComponent implements OnInit {

  steps: any[] = [];



  currentStep = 1;


  constructor(
    private router: Router, private route: ActivatedRoute,
    private biodataService: BiodataService,
    private authService: AuthService
  ) {}
  ngOnInit() {
     this.loadSteps();
    // Subscribe to the deepest child route that contains 'step' param
    this.route.paramMap.subscribe(() => {
      let child = this.route;
      while (child.firstChild) {
        child = child.firstChild;
      }
      child.paramMap.subscribe(params => {
        this.currentStep = Number(params.get('step')) || 1;
      });
    });
  }
  loadSteps() {
    this.biodataService.getSteps().subscribe(res => {
      this.steps = res;
    });
}
  goToStep(stepId: number) {

    debugger;
     this.currentStep = stepId;
    this.router.navigate(['/dashboard/editbio', stepId]);
  }
}
