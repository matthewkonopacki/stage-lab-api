'use client';

import Calendar from '../../../components/Calendar';

export default function CalendarSection() {
  return (
    <div className="bg-white rounded-xl border border-slate-200 p-4 flex-1 flex flex-col min-h-0">
      <div className="flex items-center justify-between mb-4 shrink-0">
        <h2 className="text-lg font-bold text-slate-900">Calendar</h2>
      </div>
      <div className="flex-1 min-h-0">
        <Calendar />
      </div>
    </div>
  );
}