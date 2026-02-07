
export default function PublicLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return ((
    <div className="min-h-screen flex">
      <div className="min-h-screen flex-1 bg-[linear-gradient(135deg,#0f172a_0%,#112a4d_100%)]">
        <div className="h-full p-12 flex flex-col justify-between">
          <h1 className="text-5xl text-slate-50 font-black tracking-tight flex-1">
            StageLab
          </h1>
          <div className="max-w-lg">
            <h3 className="text-3xl text-slate-50 font-black tracking-tight flex-1 mb-5">
              Empowering performance through seamless orchestration.
            </h3>
            <h4 className="text-2xl text-slate-50 font-100 tracking-tight flex-1">
              Join the world's leading performing arts organizations in managing
              rehearsals, talent, and social connectivity in one unified
              workspace.
            </h4>
          </div>
          <div className="flex flex-col flex-1 justify-end">
            <h4 className="text-lg text-slate-50 font-100 tracking-tight">
              Trusted by 200+ ensembles
            </h4>
          </div>
        </div>
      </div>
      <div className="min-h-screen flex-1 bg-slate-50">
        <div className="w-full h-full flex items-center justify-center p-8 md:p-16 lg:p-24 flex flex-col">
          {children}
        </div>
      </div>
    </div>
  ));
}