import { Rating } from './rating';

export class Review {
  id: string;
  positionId: string;
  candidateId: string;
  reviewerId: string;
  callback: boolean;
  ratings: Rating[];
  notes: string;
  created: Date;
  updated: Date;
}
