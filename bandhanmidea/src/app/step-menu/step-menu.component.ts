import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-step-menu',
  templateUrl: './step-menu.component.html',
  styleUrls: ['./step-menu.component.css']
})
export class StepMenuComponent implements OnInit {

  steps = [
    { id: 1, label: 'সাধারণ তথ্য' },
    { id: 2, label: 'ঠিকানা' },
    { id: 3, label: 'শিক্ষাগত যোগ্যতা' },
    { id: 4, label: 'পারিবারিক তথ্য' },
    { id: 5, label: 'ব্যক্তিগত তথ্য' },
    { id: 6, label: 'পেশাগত তথ্য' },
    { id: 7, label: 'বিবাহ সম্পর্কিত' },
    { id: 8, label: 'প্রতিদিনের জীবনধারা' },
    { id: 9, label: 'অতিরিক্ত তথ্য' },
    { id: 10, label: 'যোগাযোগ' }
  ];

  currentStep = 1;

  constructor(private router: Router, private route: ActivatedRoute) {}

  ngOnInit() {
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

  goToStep(stepId: number) {
     this.currentStep = stepId;
    this.router.navigate(['/dashboard/editbio', stepId]);
  }
}
