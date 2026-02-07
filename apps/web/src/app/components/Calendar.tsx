'use client';
import { useCallback } from 'react';

export interface CalendarEvent {
  id: string;
  title: string;
  start: string;
  end: string;
  description?: string;
}

function ColoredEvent({ subject, color }: { subject?: string; color?: string }) {
  const ref = useCallback((node: HTMLDivElement | null) => {
    if (node && color) {
      const appointment = node.closest('.sf-appointment') as HTMLElement;
      if (appointment) {
        appointment.style.background = color;
      }
    }
  }, [color]);

  return (
    <div ref={ref} className="sf-appointment-details">
      <div className="sf-subject" style={{ color: 'white' }}>{subject}</div>
    </div>
  );
}

export default function Calendar() {
  const defaultData = [
    {
      Id: 1,
      Subject: 'Team Meeting',
      StartTime: new Date(2025, 10, 10, 10, 30),
      EndTime: new Date(2025, 10, 12, 11, 30),
      Location: 'Conference Room A',
      Description: 'Regular team status meeting',
      CategoryColor: '#357cd2',
    },
    {
      Id: 2,
      Subject: 'Project Review',
      StartTime: new Date(2025, 10, 14, 11, 30),
      EndTime: new Date(2025, 10, 14, 16, 30),
      Location: 'Conference Room B',
      Description: 'Review project progress and discuss next steps',
      CategoryColor: '#1aaa55',
    },
  ];

  const eventTemplate = (props: Record<string, unknown>) => (
    <ColoredEvent subject={props.subject as string} color={props.CategoryColor as string} />
  );

  const eventSettings: EventSettings = { dataSource: defaultData, template: eventTemplate };

  return (
    <div className="calendar-wrapper h-full overflow-hidden bg-white">
    </div>
  );
}